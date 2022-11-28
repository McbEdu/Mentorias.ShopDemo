using McbEdu.Mentorias.ShopDemo.Domain.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Services.Customers.Interfaces;

public interface ICustomerService
{
    Task ImportCustomerAsync(ImportCustomerServiceInput input);
}
