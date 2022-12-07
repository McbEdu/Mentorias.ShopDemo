using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;

public abstract class OrderBase
{
    protected OrderBase(Guid identifier, Code code, DateTime orderTime, CustomerBase customer, List<ItemBase> items, TypeOrder typeOrder)
    {
        Identifier = identifier;
        Code = code;
        OrderTime = orderTime;
        Customer = customer;
        Items = items;
        TypeOrder = typeOrder;
    }

    public Guid Identifier { get; init; }
    public Code Code { get; private set; }
    public DateTime OrderTime { get; private set; }
    public CustomerBase Customer { get; private set; }
    public List<ItemBase> Items { get; private set; }
    public TypeOrder TypeOrder { get; init; }
}
