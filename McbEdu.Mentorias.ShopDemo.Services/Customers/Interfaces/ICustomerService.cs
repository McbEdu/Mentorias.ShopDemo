using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

public interface ICustomerService
{
    Task<bool> ImportCustomerAsync(ImportCustomerServiceInput input);
    Task<bool> VerifyCustomerIsRegistered(ImportCustomerServiceInput input);
    Task<bool> VerifyCustomerIsValid(ImportCustomerServiceInput input);
    Task<bool> VerifyListCustomerIsValid(List<ImportCustomerServiceInput> input);
    Task<Customer> GetCustomerAsync(ImportCustomerServiceInput input);
}
