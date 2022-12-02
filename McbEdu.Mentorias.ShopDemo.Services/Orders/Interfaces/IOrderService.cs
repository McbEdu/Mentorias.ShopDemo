using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;

public interface IOrderService
{
    Task<bool> ImportOrderAsync(ImportOrderServiceInput input);
    Task<bool> VerifyOrderIsRegisteredAsync(ImportOrderServiceInput input);
    Task<bool> VerifyOrderIsValidAsync(ImportOrderServiceInput input);
    Task ImportOrderAsync(Order input);
}
