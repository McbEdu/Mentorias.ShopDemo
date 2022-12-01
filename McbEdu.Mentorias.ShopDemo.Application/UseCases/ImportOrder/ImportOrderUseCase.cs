using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder;

public class ImportOrderUseCase : IUseCase<ImportOrderUseCaseInput>
{
    private readonly IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> _adapterOrder;
    private readonly IOrderService _orderService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public ImportOrderUseCase(IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput> adapterOrder, IOrderService orderService,
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _adapterOrder = adapterOrder;
        _orderService = orderService;
        _notificationPublisher = notificationPublisher; 
    }

    public async Task<bool> ExecuteAsync(ImportOrderUseCaseInput useCaseInput)
    {
        var serviceAdaptedOrder = _adapterOrder.Adapt(useCaseInput);

        if (await _orderService.VerifyOrderIsRegisteredAsync(serviceAdaptedOrder) == false)
        {
            return true;
        }
        else
        {
            _notificationPublisher.AddNotification(new NotificationItem("O pedido já foi importado!"));
            return false;
        }
    }
}
