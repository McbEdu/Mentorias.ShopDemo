﻿using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
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
        var adaptedProduct = _adapterProduct.Adapt(adapter.Product);
        return new Item()
        {
            Description = adapter.Description,
            Identifier = adapter.Identifier,
            Quantity = adapter.Quantity.GetValue(),
            Sequence = adapter.Sequence,
            UnitaryValue = adapter.UnitaryValue.GetValue(),
            ProductCode = adaptedProduct.Code,
            ProductDescription = adaptedProduct.Description
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
            var adaptedProduct = _adapterProduct.Adapt(itemAdapter.Product);
            items.Add(new Item()
            {
                Description = itemAdapter.Description,
                Identifier = itemAdapter.Identifier,
                Quantity = itemAdapter.Quantity.GetValue(),
                Sequence = itemAdapter.Sequence,
                UnitaryValue = itemAdapter.UnitaryValue.GetValue(),
                ProductCode = adaptedProduct.Code,
                ProductDescription = adaptedProduct.Description,
                ProductIdentifier = adaptedProduct.Identifier,
            });
        }

        return items;
    }
}
