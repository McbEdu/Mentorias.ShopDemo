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
        }


        await _orderService.ImportOrderAsync(dataTransferAdaptedOrder);
        return true;
    }
}
