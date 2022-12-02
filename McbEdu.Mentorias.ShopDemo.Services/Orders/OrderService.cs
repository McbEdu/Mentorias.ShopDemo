using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<Order> _orderRepository;

    public OrderService(IBaseRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<bool> ImportOrderAsync(ImportOrderServiceInput input)
    {
        throw new NotImplementedException();
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
