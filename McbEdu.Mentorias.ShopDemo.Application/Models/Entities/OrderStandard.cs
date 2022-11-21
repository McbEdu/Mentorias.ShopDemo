using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public class OrderStandard : OrderBase
{
    public OrderStandard(Guid identifier, string code, DateTime requestedOn, CustomerBase customer, List<ItemBase> items) : base(identifier, code, requestedOn, customer, items, TypeOrder.Standard)
    {
    }
}
