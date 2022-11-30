using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

public interface ICustomerService
{
    Task<bool> ImportCustomerAsync(ImportCustomerServiceInput input);
    Task<bool> VerifyCustomerIsRegistered(ImportCustomerServiceInput input);
}
