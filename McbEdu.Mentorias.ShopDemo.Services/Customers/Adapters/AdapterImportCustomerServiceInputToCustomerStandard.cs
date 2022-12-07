using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Adapters;

public class AdapterImportCustomerServiceInputToCustomerStandard : IAdapter<ImportCustomerServiceInput, CustomerBase>
{
    public ImportCustomerServiceInput Adapt(CustomerBase adapt)
    {
        throw new NotImplementedException();
    }

    public CustomerBase Adapt(ImportCustomerServiceInput adapter)
    {
        return new CustomerStandard(Guid.NewGuid(), new Name(adapter.Name), new Surname(adapter.Surname), new Email(adapter.Email), new BirthDate(adapter.BirthDate));
    }
}
