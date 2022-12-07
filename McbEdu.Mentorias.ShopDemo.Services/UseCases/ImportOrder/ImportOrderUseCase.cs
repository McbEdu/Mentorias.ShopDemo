﻿using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder;

public class ImportOrderUseCase : IUseCase<ImportOrderUseCaseInput>
{
    private readonly IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> _adapterOrder;
    private readonly IOrderService _orderService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportOrderServiceInput, OrderStandard> _adapterOrderStandard;
    private readonly IAdapter<OrderStandard, Order> _adapterDto;

    public ImportOrderUseCase(IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> adapterOrder, IOrderService orderService,
        INotificationPublisher<NotificationItem> notificationPublisher, IProductService productService, ICustomerService customerService,
        IAdapter<ImportOrderServiceInput, OrderStandard> adapterOrderStandard, IAdapter<OrderStandard, Order> adapterDto)
    {
        _adapterOrder = adapterOrder;
        _orderService = orderService;
        _notificationPublisher = notificationPublisher;
        _productService = productService;
        _customerService = customerService;
        _adapterOrderStandard = adapterOrderStandard;
        _adapterDto = adapterDto;
    }

    public async Task<bool> ExecuteAsync(ImportOrderUseCaseInput useCaseInput)
    {
        var serviceAdaptedOrder = _adapterOrder.Adapt(useCaseInput);

        if (await _orderService.VerifyOrderIsRegisteredAsync(serviceAdaptedOrder) == true)
        {
            _notificationPublisher.AddNotification(new NotificationItem("O pedido já foi importado!"));
            return false;
        }

        if (await _orderService.VerifyOrderIsValidAsync(serviceAdaptedOrder) == false) return false;


        var dataTransferAdaptedOrder = _adapterDto.Adapt(_adapterOrderStandard.Adapt(serviceAdaptedOrder));
        if (await _customerService.VerifyCustomerIsRegistered(serviceAdaptedOrder.Customer) == true)
        {
            dataTransferAdaptedOrder.Customer = await _customerService.GetCustomerAsync(serviceAdaptedOrder.Customer);
            if (serviceAdaptedOrder.Customer.Name != dataTransferAdaptedOrder.Customer.Name ||
                serviceAdaptedOrder.Customer.Surname != dataTransferAdaptedOrder.Customer.Surname ||
                serviceAdaptedOrder.Customer.BirthDate != dataTransferAdaptedOrder.Customer.BirthDate)
            {
                _notificationPublisher.AddNotification(new NotificationItem("O cliente já foi importado, no entanto com dados diferentes."));
            }
        }

        for (int i = 0; i < serviceAdaptedOrder.Items.Count; i++)
        {
            if (await _productService.VerifyProductIsRegisteredAsync(serviceAdaptedOrder.Items[i].Product) == true)
            {
                dataTransferAdaptedOrder.Items[i].Product = await _productService.GetProductByCodeAsync(serviceAdaptedOrder.Items[i].Product.Code);

                if (dataTransferAdaptedOrder.Items[i].Product.Description != serviceAdaptedOrder.Items[i].Product.Description)
                {
                    _notificationPublisher.AddNotification(new NotificationItem($"O produto de código {serviceAdaptedOrder.Items[i].Product.Code} já foi importado, mas possui dados diferentes."));
                }
            }
        }

        /*
         * E, caso existam dois itens ou mais com o mesmo produto, somente um item de produto deve ser importado contendo a soma de 
         * todas as quantidades, a média dos valores e a junção das descrições.
         */
        dataTransferAdaptedOrder.Items = dataTransferAdaptedOrder.Items
            .GroupBy(i => i.Product.Code)
            .Select(p => new Item()
            {
                Identifier = p.First().Identifier,
                Sequence = p.First().Sequence,
                UnitaryValue = new UnitaryValue(p.Average(ip => ip.UnitaryValue.GetValue())),
                Description = string.Concat(p.Select(p => p.Description + " ")),
                Product = p.First().Product,
                Quantity = p.Sum(ip => ip.Quantity)
            }).ToList();

        for (int i =0; i < dataTransferAdaptedOrder.Items.Count; i++)
        {
            dataTransferAdaptedOrder.Items[i].Sequence = i + 1;
        }
        

        await _orderService.ImportOrderAsync(dataTransferAdaptedOrder);
        return true;
    }
}
