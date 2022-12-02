using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterImportItemServiceInputToItemStandard : IAdapter<ImportItemServiceInput, ItemStandard>
{
    private readonly IAdapter<ImportProductServiceInput, ProductStandard> _adapterProduct;

    public AdapterImportItemServiceInputToItemStandard(IAdapter<ImportProductServiceInput, ProductStandard> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ImportItemServiceInput Adapt(ItemStandard adapt)
    {
        throw new NotImplementedException();
    }

    public ItemStandard Adapt(ImportItemServiceInput adapter)
    {
        return new ItemStandard(Guid.NewGuid(), adapter.Description, adapter.Sequence, adapter.Quantity, _adapterProduct.Adapt(adapter.Product), adapter.UnitaryValue);
    }
}
