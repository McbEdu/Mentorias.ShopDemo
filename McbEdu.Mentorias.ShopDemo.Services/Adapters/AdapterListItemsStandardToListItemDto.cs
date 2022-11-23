﻿using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterListItemsStandardToListItemDto : IAdapter<List<Item>, List<ItemStandard>>
{
    private readonly IAdapter<Item, ItemStandard> _adapterListItems;

    public AdapterListItemsStandardToListItemDto(IAdapter<Item, ItemStandard> adapterListItems)
    {
        _adapterListItems = adapterListItems;
    }

    public List<Item> Adapt(List<ItemStandard> adapter)
    {
        var adapteeList = new List<Item>();

        foreach (var adaptant in adapter)
        {
            adapteeList.Add(_adapterListItems.Adapt(adaptant));
        }

        return adapteeList;
    }
}
