using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities;

public class OrderStandard : OrderBase
{
    public OrderStandard(Guid identifier, Code code, DateTime orderTime, CustomerBase customer, List<ItemBase> items) 
        : base(identifier, code, orderTime, customer, items, TypeOrder.Standard)
    {
    }
}
