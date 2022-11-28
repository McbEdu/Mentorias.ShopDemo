using McbEdu.Mentorias.ShopDemo.Domain.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Services.Customers.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Domain.Services.Customers;

public class CustomerService : ICustomerService
{
    public CustomerService()
    {

    }

    public Task ImportCustomerAsync(ImportCustomerServiceInput input)
    {
        throw new NotImplementedException();
    }
}
