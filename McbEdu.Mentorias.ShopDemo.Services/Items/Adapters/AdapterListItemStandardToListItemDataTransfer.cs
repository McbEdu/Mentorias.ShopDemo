using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterListItemStandardToListItemDataTransfer : IAdapter<List<ItemStandard>, List<Item>>
{
    private readonly IAdapter<Product, ProductStandard> _adapterProduct;

    public AdapterListItemStandardToListItemDataTransfer(IAdapter<Product, ProductStandard> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public Item Adapt(ItemStandard adapter)
    {
        return new Item()
        {
            Description = adapter.Description,
            Identifier = adapter.Identifier,
            Quantity = adapter.Quantity,
            Sequence = adapter.Sequence,
            UnitaryValue = adapter.UnitaryValue,
            Product = _adapterProduct.Adapt(adapter.ProductStandard)
        };
    }

    public List<ItemStandard> Adapt(List<Item> adapt)
    {
        throw new NotImplementedException();
    }

    public List<Item> Adapt(List<ItemStandard> adapter)
    {
        var items = new List<Item>();

        foreach (var itemAdapter in adapter)
        {
            items.Add(new Item()
            {
                Description = itemAdapter.Description,
                Identifier = itemAdapter.Identifier,
                Quantity = itemAdapter.Quantity,
                Sequence = itemAdapter.Sequence,
                UnitaryValue = itemAdapter.UnitaryValue,
                Product = _adapterProduct.Adapt(itemAdapter.ProductStandard)
            });
        }

        return items;
    }
}
