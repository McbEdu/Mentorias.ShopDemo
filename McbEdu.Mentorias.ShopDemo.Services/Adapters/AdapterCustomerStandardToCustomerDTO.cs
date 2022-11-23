using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public sealed class AdapterCustomerStandardToCustomerDTO : IAdapter<Customer, CustomerStandard> 
{
    public Customer Adapt(CustomerStandard adapter)
    {
        return new Customer() 
        { 
            Birthday = adapter.Birthday,
            Email = adapter.Email,
            Identifier = adapter.Identifier,
            Name = adapter.Name,
            Surname = adapter.Surname,
        };
    }
}
