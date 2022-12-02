using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
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

    public OrderService(
        IExtendsOrderRepository orderRepository,
        IAdapter<ImportOrderServiceInput, OrderStandard> adapterOrderStandard,
        IAdapter<OrderStandard, Order> adapterOrderDataTransfer)
    {
        _orderRepository = orderRepository;
        _adapterOrderStandard = adapterOrderStandard;
        _adapterOrderDataTransfer = adapterOrderDataTransfer;
    }

    public Task<bool> ImportOrderAsync(ImportOrderServiceInput input)
    {
        _orderRepository.AddAsync(_adapterOrderDataTransfer.Adapt(_adapterOrderStandard.Adapt(input)));

        return Task.FromResult(true);
    }

    public Task<bool> VerifyOrderIsRegisteredAsync(ImportOrderServiceInput input)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyOrderIsValidAsync(ImportOrderServiceInput input)
    {
        throw new NotImplementedException();
    }
}
