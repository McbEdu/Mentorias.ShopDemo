using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterListImportItemServiceInputToListItemStandard : IAdapter<List<ImportItemServiceInput>, List<ItemStandard>>
{
    private readonly IAdapter<ImportItemServiceInput, ItemStandard> _adapterItem;

    public AdapterListImportItemServiceInputToListItemStandard(IAdapter<ImportItemServiceInput, ItemStandard> adapterItem)
    {
        _adapterItem = adapterItem;
    }

    public List<ImportItemServiceInput> Adapt(List<ItemStandard> adapt)
    {
        throw new NotImplementedException();
    }

    public List<ItemStandard> Adapt(List<ImportItemServiceInput> adapter)
    {
        var itemsStandard = new List<ItemStandard>();

        foreach (var item in adapter)
        {
            itemsStandard.Add(_adapterItem.Adapt(item));
        }

        return itemsStandard;
    }
}
