using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Adapters;

public class AdapterImportCustomerServiceInputToCustomerStandard : IAdapter<ImportCustomerServiceInput, CustomerStandard>
{
    public ImportCustomerServiceInput Adapt(CustomerStandard adapt)
    {
        throw new NotImplementedException();
    }

    public CustomerStandard Adapt(ImportCustomerServiceInput adapter)
    {
        return new CustomerStandard(Guid.NewGuid(), adapter.Name, adapter.Surname, adapter.Email, adapter.BirthDate);
    }
}
