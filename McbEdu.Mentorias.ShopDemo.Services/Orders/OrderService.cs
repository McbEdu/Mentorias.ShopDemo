using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IExtendsOrderRepository _orderRepository;
    private readonly IAdapter<ImportOrderServiceInput, OrderStandard> _adapterOrderStandard;
    private readonly IAdapter<OrderStandard, Order> _adapterOrderDataTransfer;
    private readonly AbstractValidator<OrderStandard> _orderValidator;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;

    public OrderService(
        IExtendsOrderRepository orderRepository,
        IAdapter<ImportOrderServiceInput, OrderStandard> adapterOrderStandard,
        IAdapter<OrderStandard, Order> adapterOrderDataTransfer,
        AbstractValidator<OrderStandard> orderValidator,
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
