using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.Adapters;

public class AdapterImportItemUseCaseInputToServiceInput : IAdapter<ImportItemUseCaseInput, ImportItemServiceInput>
{
    private readonly IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> _adapterProduct;

    public AdapterImportItemUseCaseInputToServiceInput(IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ImportItemUseCaseInput Adapt(ImportItemServiceInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportItemServiceInput Adapt(ImportItemUseCaseInput adapter)
    {
        return new ImportItemServiceInput(adapter.Sequence, adapter.Quantity, adapter.UnitaryValue, adapter.Description, _adapterProduct.Adapt(adapter.Product));
    }
}
