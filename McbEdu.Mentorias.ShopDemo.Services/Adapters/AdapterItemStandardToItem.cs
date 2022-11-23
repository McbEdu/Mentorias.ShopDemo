using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterItemStandardToItem : IAdapter<Item, ItemStandard>
{
    private readonly IAdapter<Product, ProductStandard> _adapterProduct;

    public AdapterItemStandardToItem(IAdapter<Product, ProductStandard> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public Item Adapt(ItemStandard adapter)
    {
        return new Item()
        {
            Identifier = Guid.NewGuid(),
            Description = adapter.Description,
            Sequence = adapter.Sequence,
            Quantity = adapter.Quantity,
            UnitaryValue = adapter.UnitaryValue,
            Product = _adapterProduct.Adapt((ProductStandard)adapter.Product)
        };
    }
}
