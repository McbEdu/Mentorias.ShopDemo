using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterCustomerDTOToCustomerStandard : IAdapter<CustomerStandard, Customer>
{
    public CustomerStandard Adapt(Customer adapter)
    {
        return new CustomerStandard(adapter.Identifier, adapter.Name, adapter.Surname, adapter.Email, adapter.Birthday);
    }
}
