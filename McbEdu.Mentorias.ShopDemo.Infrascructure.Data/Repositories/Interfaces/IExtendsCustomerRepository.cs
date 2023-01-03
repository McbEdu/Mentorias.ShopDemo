using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

public interface IExtendsCustomerRepository : IBaseRepository<Customer>
{
    Task<bool> VerifyEntityExistsAsync(string email);
    Task<bool> VerifyEntityExistsLocalAsync(string email);
    Task<Customer> GetByEmail(string email);
    Task<List<Customer>> GetCustomerByPaginationOrderringByNameAndSurnameAsync(int index, int offset);
    Task<List<Customer>> GetCustomerByPaginationFilteredByEmail(int index, int offset);
    Task<List<Customer>> GetCustomerByPaginationFilteredByNameOrSurname(int index, int offset);
    Task<List<Customer>> GetCustomerByPaginationFilteredByRangeBirthDate(int index, int offset);
}
