
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;

public class AdapterImportOrderUseCaseInputToServiceInput : IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput>
{
    private readonly IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> _adapterCustomer;
    private readonly IAdapter<List<ImportItemUseCaseInput>, List<ImportItemServiceInput>> _adapterItems;

    public AdapterImportOrderUseCaseInputToServiceInput(
        IAdapter<List<ImportItemUseCaseInput>, List<ImportItemServiceInput>> adapterItems,
        IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> adapterCustomer
        )
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;
    }

    public ImportOrderUseCaseInput Adapt(ImportOrderServiceInput adapt)
    {
        throw new NotImplementedException();
    }

    public ImportOrderServiceInput Adapt(ImportOrderUseCaseInput adapter)
    {
        return new ImportOrderServiceInput(adapter.Code, adapter.OrderTime, _adapterCustomer.Adapt(adapter.Customer), _adapterItems.Adapt(adapter.Items));
    }
}
