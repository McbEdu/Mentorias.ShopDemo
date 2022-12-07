using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Adapters;

public class AdapterImportOrderServiceInputToOrderStandard : IAdapter<ImportOrderServiceInput, OrderBase>
{
    private readonly IAdapter<List<ImportItemServiceInput>, List<ItemBase>> _adapterItems;
    private readonly IAdapter<ImportCustomerServiceInput, CustomerBase> _adapterCustomer;

    public AdapterImportOrderServiceInputToOrderStandard(
        IAdapter<List<ImportItemServiceInput>, List<ItemBase>> adapterItems,
        IAdapter<ImportCustomerServiceInput, CustomerBase> adapterCustomer)
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;
    }

    public ImportOrderServiceInput Adapt(OrderBase adapt)
    {
        throw new NotImplementedException();
    }

    public OrderBase Adapt(ImportOrderServiceInput adapter)
    {
        return new OrderStandard(Guid.NewGuid(), new Code(adapter.Code), adapter.OrderTime, _adapterCustomer.Adapt(adapter.Customer), _adapterItems.Adapt(adapter.Items));
    }
}
