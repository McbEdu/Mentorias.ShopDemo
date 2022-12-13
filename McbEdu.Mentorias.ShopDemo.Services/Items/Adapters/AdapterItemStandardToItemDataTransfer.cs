using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterItemStandardToItemDataTransfer : IAdapter<ItemBase, Item>
{
    private readonly IAdapter<Product, ProductBase> _adapterProduct;

    public AdapterItemStandardToItemDataTransfer(IAdapter<Product, ProductBase> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ItemBase Adapt(Item adapt)
    {
        throw new NotImplementedException();
    }

    public Item Adapt(ItemBase adapter)
    {
        var adaptedProduct = _adapterProduct.Adapt(adapter.Product);
        return new Item()
        {
            Description = adapter.Description,
            Identifier = adapter.Identifier,
            ProductCode = adaptedProduct.Code,
            ProductDescription = adaptedProduct.Description,
            ProductIdentifier = adaptedProduct.Identifier,
            Quantity = adapter.Quantity.GetValue(),
            Sequence = adapter.Sequence,
            UnitaryValue = adapter.UnitaryValue.GetValue(),
        };
    }
}
