using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterOrderStandardToOrderDTO : IAdapter<Order, OrderStandard>
{
    private readonly IAdapter<Customer, CustomerStandard> _adapterCustomer;
    private readonly IAdapter<List<Item>, List<ItemStandard>> _adapterItems;

    public AdapterOrderStandardToOrderDTO(IAdapter<Customer, CustomerStandard> adapterCustomer,
        IAdapter<List<Item>, List<ItemStandard>> adapterItems)
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;   
    }

    public Order Adapt(OrderStandard adapter)
    {
        return new Order()
        {
            Code = adapter.Code,
            Customer = _adapterCustomer.Adapt(adapter.Customer),
            Identifier= adapter.Identifier,
            Items = _adapterItems.Adapt(adapter.Items),
            RequestedOn = adapter.RequestedOn,
        };
    }
}
