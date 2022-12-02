using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;

public class AdapterListImportItemUseCaseInputToListServiceInput : IAdapter<List<ImportItemUseCaseInput>, List<ImportItemServiceInput>>
{
    private readonly IAdapter<ImportItemUseCaseInput, ImportItemServiceInput> _adapterItem;

    public AdapterListImportItemUseCaseInputToListServiceInput(IAdapter<ImportItemUseCaseInput, ImportItemServiceInput> adapterItem)
    {
        _adapterItem = adapterItem;
    }

    public List<ImportItemUseCaseInput> Adapt(List<ImportItemServiceInput> adapt)
    {
        throw new NotImplementedException();
    }

    public List<ImportItemServiceInput> Adapt(List<ImportItemUseCaseInput> adapter)
    {
        var serviceInputs = new List<ImportItemServiceInput>();

        foreach (var item in adapter)
        {
            serviceInputs.Add(_adapterItem.Adapt(item));
        }

        return serviceInputs;
    }
}
