using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

public interface IExtendsCustomerRepository : IBaseRepository<Customer>
{
    Task<bool> VerifyEntityExistsAsync(string email);
    Task<bool> VerifyEntityExistsLocalAsync(string email);
    Task<Customer> GetByEmail(string email);
}
