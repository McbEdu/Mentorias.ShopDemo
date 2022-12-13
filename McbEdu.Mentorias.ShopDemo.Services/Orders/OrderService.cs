using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IExtendsOrderRepository _orderRepository;
    private readonly IAdapter<ImportOrderServiceInput, OrderBase> _adapterOrderStandard;
    private readonly IAdapter<OrderBase, Order> _adapterOrderDataTransfer;
    private readonly AbstractValidator<OrderBase> _orderValidator;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;

    public OrderService(
        IExtendsOrderRepository orderRepository,
        IAdapter<ImportOrderServiceInput, OrderBase> adapterOrderStandard,
        IAdapter<OrderBase, Order> adapterOrderDataTransfer,
        AbstractValidator<OrderBase> orderValidator,
        INotificationPublisher<NotificationItem> notificationPublisher,
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications)
    {
        _orderRepository = orderRepository;
        _adapterOrderStandard = adapterOrderStandard;
        _adapterOrderDataTransfer = adapterOrderDataTransfer;
        _orderValidator = orderValidator;
        _notificationPublisher = notificationPublisher;
        _adapterNotifications = adapterNotifications;
    }

    public async Task<bool> ImportOrderAsync(ImportOrderServiceInput input)
    {
        var orderStandard = _adapterOrderStandard.Adapt(input);

        var validationResult = _orderValidator.Validate(orderStandard);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return false;
        }

        if (await _orderRepository.VerifyOrderIsRegisteredByCode(input.Code))
        {
            _notificationPublisher.AddNotification(new NotificationItem("O pedido já foi importado!"));
            return false;
        }

        var dataTransferAdaptedOrder = _adapterOrderDataTransfer.Adapt(_adapterOrderStandard.Adapt(input));
        dataTransferAdaptedOrder.Items = dataTransferAdaptedOrder.Items
            .GroupBy(i => i.ProductCode)
            .Select(p => new Item()
            {
                Identifier = p.First().Identifier,
                Sequence = p.First().Sequence,
                UnitaryValue = p.Average(ip => ip.UnitaryValue),
                Description = string.Concat(p.Select(p => p.Description + " ")),
                ProductCode = p.First().ProductCode,
                ProductDescription = p.First().ProductDescription,
                Quantity = p.Sum(ip => ip.Quantity)
            }).ToList();

        for (int i = 0; i < dataTransferAdaptedOrder.Items.Count; i++)
        {
            dataTransferAdaptedOrder.Items[i].Sequence = i + 1;
        }

        await _orderRepository.AddAsync(dataTransferAdaptedOrder);

        return true;
    }
}
