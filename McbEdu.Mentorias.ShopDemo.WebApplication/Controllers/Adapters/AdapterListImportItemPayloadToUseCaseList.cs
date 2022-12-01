using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;

public class AdapterListImportItemPayloadToUseCaseList : IAdapter<List<ImportItemPayload>, List<ImportItemUseCaseInput>>
{
    private readonly IAdapter<ImportItemPayload, ImportItemUseCaseInput> _adapterItem;

    public AdapterListImportItemPayloadToUseCaseList(IAdapter<ImportItemPayload, ImportItemUseCaseInput> adapterItem)
    {
        _adapterItem = adapterItem;
    }


    public List<ImportItemPayload> Adapt(List<ImportItemUseCaseInput> adapt)
    {
        throw new NotImplementedException();
    }

    public List<ImportItemUseCaseInput> Adapt(List<ImportItemPayload> adapter)
    {
        var useCasesInputList = new List<ImportItemUseCaseInput>();

        foreach (var item in adapter)
        {
            useCasesInputList.Add(_adapterItem.Adapt(item));
        }

        return useCasesInputList;
    }
}
