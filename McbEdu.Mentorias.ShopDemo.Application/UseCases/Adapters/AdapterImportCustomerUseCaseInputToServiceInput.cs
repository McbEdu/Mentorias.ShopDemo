using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;

public class AdapterImportCustomerUseCaseInputToServiceInput : IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput>
{
    public ImportCustomerUseCaseInput Adapt(ImportCustomerServiceInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportCustomerServiceInput Adapt(ImportCustomerUseCaseInput adapter)
    { 
        return new ImportCustomerServiceInput(adapter.Name, adapter.Surname, adapter.Email, adapter.BirthDate);
    }
}
