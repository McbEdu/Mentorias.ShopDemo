using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;

public class AdapterImportProductPayloadToUseCase : IAdapter<ImportProductPayload, ImportProductUseCaseInput>
{
    public ImportProductPayload Adapt(ImportProductUseCaseInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportProductUseCaseInput Adapt(ImportProductPayload adapter)
    {
        return new ImportProductUseCaseInput(adapter.Code, adapter.Description);
    }
}
