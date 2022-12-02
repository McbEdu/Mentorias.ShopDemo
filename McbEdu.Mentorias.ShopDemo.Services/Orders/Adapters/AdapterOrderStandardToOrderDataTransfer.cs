using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Adapters;

public class AdapterOrderStandardToOrderDataTransfer : IAdapter<OrderStandard, Order>
{
    private readonly IAdapter<CustomerStandard, Customer> _adapterCustomer;
    private readonly IAdapter<List<ItemStandard>, List<Item>> _adapterItems;

    public AdapterOrderStandardToOrderDataTransfer(
        IAdapter<List<ItemStandard>, List<Item>> adapterItems,
        IAdapter<CustomerStandard, Customer> adapterCustomer)
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;
    }

    public OrderStandard Adapt(Order adapt)
    {
        throw new NotImplementedException();
    }

    public Order Adapt(OrderStandard adapter)
    {
        return new Order()
        {
            Code = adapter.Code,
            Identifier = adapter.Identifier,
            OrderTime = adapter.OrderTime,
            Customer = _adapterCustomer.Adapt(adapter.Customer),
            Items = _adapterItems.Adapt(adapter.Items)
        };
    }
}
