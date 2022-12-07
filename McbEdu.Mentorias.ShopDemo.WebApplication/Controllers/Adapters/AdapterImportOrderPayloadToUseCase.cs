using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;

public class AdapterImportOrderPayloadToUseCase : IAdapter<ImportOrderPayload, ImportOrderUseCaseInput>
{
    private readonly IAdapter<List<ImportItemPayload>, List<ImportItemUseCaseInput>> _adapterItems;
    private readonly IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput> _adapterCustomer;

    public AdapterImportOrderPayloadToUseCase(IAdapter<List<ImportItemPayload>, List<ImportItemUseCaseInput>> adapterItems,
        IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput> adapterCustomer)
    {
        _adapterItems = adapterItems;
        _adapterCustomer = adapterCustomer;
    }

    public ImportOrderPayload Adapt(ImportOrderUseCaseInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportOrderUseCaseInput Adapt(ImportOrderPayload adapter)
    {
        return new ImportOrderUseCaseInput(adapter.Code, adapter.OrderTime, _adapterCustomer.Adapt(adapter.Customer), _adapterItems.Adapt(adapter.Items));
    }
}
