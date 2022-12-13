using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;

public interface IOrderService
{
    Task<bool> ImportOrderAsync(ImportOrderServiceInput input);
}
