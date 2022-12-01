using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;

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
