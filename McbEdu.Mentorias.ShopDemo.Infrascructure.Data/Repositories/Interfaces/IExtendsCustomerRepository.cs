using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

public interface IExtendsCustomerRepository : IBaseRepository<Customer>
{
    Task<bool> VerifyEntityExistsAsync(string email);
    Task<Customer> GetByEmail(string email);
}
