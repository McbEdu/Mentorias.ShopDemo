using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public sealed class AdapterCreateCustomerInputModelToCustomerStandard : IAdapter<CustomerStandard, CreateCustomerInputModel>
{
    public CustomerStandard Adapt(CreateCustomerInputModel adapter)
    {
        return new CustomerStandard(Guid.NewGuid(), adapter.Name, adapter.Surname, adapter.Email, adapter.Birthday);
    }
}