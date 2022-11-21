using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterListCreateItemInputModelToListItemStandard : IAdapter<List<ItemBase>, List<CreateItemInputModel>>
{
    private readonly IAdapter<ItemStandard, CreateItemInputModel> _adapterItem;

    public AdapterListCreateItemInputModelToListItemStandard(IAdapter<ItemStandard, CreateItemInputModel> adapterItem)
    {
        _adapterItem = adapterItem;
    }

    public List<ItemBase> Adapt(List<CreateItemInputModel> adapter)
    {
        var itemsStandard = new List<ItemBase>();

        foreach (var adaptant in adapter)
        {
            itemsStandard.Add(_adapterItem.Adapt(adaptant));
        }

        return itemsStandard;
    }
}
