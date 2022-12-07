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

    public Task<bool> ImportOrderAsync(ImportOrderServiceInput input)
    {
        _orderRepository.AddAsync(_adapterOrderDataTransfer.Adapt(_adapterOrderStandard.Adapt(input)));

        return Task.FromResult(true);
    }

    public async Task ImportOrderAsync(Order input)
    {
        await _orderRepository.AddAsync(input);
    }

    public async Task<bool> VerifyOrderIsRegisteredAsync(ImportOrderServiceInput input)
    {
        return await _orderRepository.VerifyOrderIsRegisteredByCode(input.Code);
    }

    public Task<bool> VerifyOrderIsValidAsync(ImportOrderServiceInput input)
    {
        var orderStandard = _adapterOrderStandard.Adapt(input);

        var validationResult = _orderValidator.Validate(orderStandard);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}
