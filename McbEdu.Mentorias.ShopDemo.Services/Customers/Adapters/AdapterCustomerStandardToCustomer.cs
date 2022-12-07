using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Adapters;

public class AdapterCustomerStandardToCustomer : IAdapter<CustomerStandard, Customer>
{
    public CustomerStandard Adapt(Customer adapt)
    {
        throw new NotImplementedException();
    }

    public Customer Adapt(CustomerStandard adapter)
    {
        return new Customer()
        {
            Identifier = adapter.Identifier,
            BirthDate = adapter.BirthDate,
            Email = adapter.Email,
            Name = adapter.Name,
            Surname = adapter.Surname
        };
    }
}
