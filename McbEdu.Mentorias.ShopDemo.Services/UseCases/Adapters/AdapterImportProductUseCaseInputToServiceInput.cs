using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.Adapters;

public class AdapterImportProductUseCaseInputToServiceInput : IAdapter<ImportProductUseCaseInput, ImportProductServiceInput>
{
    public ImportProductUseCaseInput Adapt(ImportProductServiceInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportProductServiceInput Adapt(ImportProductUseCaseInput adapter)
    {
        return new ImportProductServiceInput(adapter.Code, adapter.Description);
    }
}
