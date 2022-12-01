using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders;

public class OrderService : IOrderService
{
    public OrderService()
    {

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
