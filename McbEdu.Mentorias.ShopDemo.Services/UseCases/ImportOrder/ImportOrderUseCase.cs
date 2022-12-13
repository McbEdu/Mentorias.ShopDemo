using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder;

public class ImportOrderUseCase : IUseCase<ImportOrderUseCaseInput>
{
    private readonly IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> _adapterOrder;
    private readonly IOrderService _orderService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportOrderServiceInput, OrderBase> _adapterOrderStandard;
    private readonly IAdapter<OrderBase, Order> _adapterDto;
    private readonly IUnitOfWork _unitOfWork;

    public ImportOrderUseCase(IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> adapterOrder, IOrderService orderService,
        INotificationPublisher<NotificationItem> notificationPublisher, IProductService productService, ICustomerService customerService,
        IAdapter<ImportOrderServiceInput, OrderBase> adapterOrderStandard, IAdapter<OrderBase, Order> adapterDto, IUnitOfWork unitOfWork)
    {
        _adapterOrder = adapterOrder;
        _orderService = orderService;
        _notificationPublisher = notificationPublisher;
        _productService = productService;
        _customerService = customerService;
        _adapterOrderStandard = adapterOrderStandard;
        _adapterDto = adapterDto;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(ImportOrderUseCaseInput useCaseInput)
    {
        var serviceAdaptedOrder = _adapterOrder.Adapt(useCaseInput);
        return await _unitOfWork.ExecuteAsync((async () =>
        {
            return await _orderService.ImportOrderAsync(serviceAdaptedOrder);
        }));
    }
}
