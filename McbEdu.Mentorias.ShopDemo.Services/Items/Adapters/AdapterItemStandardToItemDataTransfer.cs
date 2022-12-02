using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterItemStandardToItemDataTransfer : IAdapter<ItemStandard, Item>
{
    private readonly IAdapter<Product, ProductStandard> _adapterProduct;

    public AdapterItemStandardToItemDataTransfer(IAdapter<Product, ProductStandard> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ItemStandard Adapt(Item adapt)
    {
        throw new NotImplementedException();
    }

    public Item Adapt(ItemStandard adapter)
    {
        return new Item()
        {
            Description = adapter.Description,
            Identifier = adapter.Identifier,
            Product = _adapterProduct.Adapt(adapter.ProductStandard),
            Quantity = adapter.Quantity,
            Sequence = adapter.Sequence,
            UnitaryValue = adapter.UnitaryValue
        };
    }
}
