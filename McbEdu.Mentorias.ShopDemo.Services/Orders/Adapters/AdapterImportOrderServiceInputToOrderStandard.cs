using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Adapters;

public class AdapterImportOrderServiceInputToOrderStandard : IAdapter<ImportOrderServiceInput, OrderStandard>
{
    private readonly IAdapter<List<ImportItemServiceInput>, List<ItemStandard>> _adapterItems;
    private readonly IAdapter<ImportCustomerServiceInput, CustomerStandard> _adapterCustomer;

    public AdapterImportOrderServiceInputToOrderStandard(
        IAdapter<List<ImportItemServiceInput>, List<ItemStandard>> adapterItems,
        IAdapter<ImportCustomerServiceInput, CustomerStandard> adapterCustomer)
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;
    }

    public ImportOrderServiceInput Adapt(OrderStandard adapt)
    {
        throw new NotImplementedException();
    }

    public OrderStandard Adapt(ImportOrderServiceInput adapter)
    {
        return new OrderStandard(Guid.NewGuid(), adapter.Code, adapter.OrderTime, _adapterItems.Adapt(adapter.Items), _adapterCustomer.Adapt(adapter.Customer));
    }
}
