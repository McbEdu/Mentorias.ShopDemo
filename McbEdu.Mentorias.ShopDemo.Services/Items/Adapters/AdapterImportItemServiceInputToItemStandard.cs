using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterImportItemServiceInputToItemStandard : IAdapter<ImportItemServiceInput, ItemBase>
{
    private readonly IAdapter<ImportProductServiceInput, ProductBase> _adapterProduct;

    public AdapterImportItemServiceInputToItemStandard(IAdapter<ImportProductServiceInput, ProductBase> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ImportItemServiceInput Adapt(ItemBase adapt)
    {
        throw new NotImplementedException();
    }

    public ItemBase Adapt(ImportItemServiceInput adapter)
    {
        return new ItemStandard(Guid.NewGuid(), adapter.Sequence, new Quantity(adapter.Quantity), adapter.Description, new UnitaryValue(adapter.UnitaryValue), _adapterProduct.Adapt(adapter.Product));
    }
}
