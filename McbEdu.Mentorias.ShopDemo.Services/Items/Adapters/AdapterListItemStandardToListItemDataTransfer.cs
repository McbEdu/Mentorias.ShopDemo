using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterListItemStandardToListItemDataTransfer : IAdapter<List<ItemBase>, List<Item>>
{
    private readonly IAdapter<Product, ProductBase> _adapterProduct;

    public AdapterListItemStandardToListItemDataTransfer(IAdapter<Product, ProductBase> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public Item Adapt(ItemBase adapter)
    {
        return new Item()
        {
            Description = adapter.Description,
            Identifier = adapter.Identifier,
            Quantity = adapter.Quantity.GetValue(),
            Sequence = adapter.Sequence,
            UnitaryValue = adapter.UnitaryValue.GetValue(),
            Product = _adapterProduct.Adapt(adapter.Product)
        };
    }

    public List<ItemBase> Adapt(List<Item> adapt)
    {
        throw new NotImplementedException();
    }

    public List<Item> Adapt(List<ItemBase> adapter)
    {
        var items = new List<Item>();

        foreach (var itemAdapter in adapter)
        {
            items.Add(new Item()
            {
                Description = itemAdapter.Description,
                Identifier = itemAdapter.Identifier,
                Quantity = itemAdapter.Quantity.GetValue(),
                Sequence = itemAdapter.Sequence,
                UnitaryValue = itemAdapter.UnitaryValue.GetValue(),
                Product = _adapterProduct.Adapt(itemAdapter.Product)
            });
        }

        return items;
    }
}
