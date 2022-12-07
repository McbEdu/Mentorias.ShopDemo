using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

public interface IExtendsOrderRepository : IBaseRepository<Order>
{
    Task<bool> VerifyOrderIsRegisteredByCode(string code);
}
