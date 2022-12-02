using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder;

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

        await _orderService.ImportOrderAsync(dataTransferAdaptedOrder);
        return true;
    }
}
