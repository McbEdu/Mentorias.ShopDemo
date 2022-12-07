using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;

public class AdapterImportItemPayloadToUseCase : IAdapter<ImportItemPayload, ImportItemUseCaseInput>
{
    private readonly IAdapter<ImportProductPayload, ImportProductUseCaseInput> _adapterProduct;

    public AdapterImportItemPayloadToUseCase(IAdapter<ImportProductPayload, ImportProductUseCaseInput> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ImportItemPayload Adapt(ImportItemUseCaseInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportItemUseCaseInput Adapt(ImportItemPayload adapter)
    {
        return new ImportItemUseCaseInput(adapter.Sequence, adapter.Description, adapter.Quantity, adapter.UnitaryValue, _adapterProduct.Adapt(adapter.Product));
    }
}
