using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;

public class AdapterImportCustomerPayloadToUseCase : IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput>
{
    public ImportCustomerPayload Adapt(ImportCustomerUseCaseInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportCustomerUseCaseInput Adapt(ImportCustomerPayload adapter)
    {
        return new ImportCustomerUseCaseInput(adapter.Name, adapter.Surname, adapter.Email, adapter.birthDate);
    }
}
