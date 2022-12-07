using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Adapters;

public class AdapterCustomerStandardToCustomer : IAdapter<CustomerBase, Customer>
{
    public CustomerBase Adapt(Customer adapt)
    {
        throw new NotImplementedException();
    }

    public Customer Adapt(CustomerBase adapter)
    {
        return new Customer()
        {
            Identifier = adapter.Identifier,
            BirthDate = adapter.BirthDate.GetValue(),
            Email = adapter.Email.ToString(),
            Name = adapter.Name.ToString(),
            Surname = adapter.Surname.ToString()
        };
    }
}
