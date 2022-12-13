using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Adapters;

public class AdapterOrderStandardToOrderDataTransfer : IAdapter<OrderBase, Order>
{
    private readonly IAdapter<CustomerBase, Customer> _adapterCustomer;
    private readonly IAdapter<List<ItemBase>, List<Item>> _adapterItems;

    public AdapterOrderStandardToOrderDataTransfer(
        IAdapter<List<ItemBase>, List<Item>> adapterItems,
        IAdapter<CustomerBase, Customer> adapterCustomer)
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;
    }

    public OrderBase Adapt(Order adapt)
    {
        throw new NotImplementedException();
    }

    public Order Adapt(OrderBase adapter)
    {
        var adaptedCustomer = _adapterCustomer.Adapt(adapter.Customer);
        return new Order()
        {
            Code = adapter.Code.ToString(),
            Identifier = adapter.Identifier,
            OrderTime = adapter.OrderTime,
            CustomerBirthdate = adaptedCustomer.BirthDate,
            CustomerEmail = adaptedCustomer.Email,
            CustomerIdentifier = adaptedCustomer.Identifier,
            CustomerName = adaptedCustomer.Name,
            CustomerSurname = adaptedCustomer.Surname,
            Items = _adapterItems.Adapt(adapter.Items)
        };
    }
}
