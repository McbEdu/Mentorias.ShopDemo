using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;

public class AdapterListImportItemServiceInputToListItemStandard : IAdapter<List<ImportItemServiceInput>, List<ItemBase>>
{
    private readonly IAdapter<ImportItemServiceInput, ItemBase> _adapterItem;

    public AdapterListImportItemServiceInputToListItemStandard(IAdapter<ImportItemServiceInput, ItemBase> adapterItem)
    {
        _adapterItem = adapterItem;
    }

    public List<ImportItemServiceInput> Adapt(List<ItemBase> adapt)
    {
        throw new NotImplementedException();
    }

    public List<ItemBase> Adapt(List<ImportItemServiceInput> adapter)
    {
        var itemsStandard = new List<ItemBase>();

        foreach (var item in adapter)
        {
            itemsStandard.Add(_adapterItem.Adapt(item));
        }

        return itemsStandard;
    }
}
