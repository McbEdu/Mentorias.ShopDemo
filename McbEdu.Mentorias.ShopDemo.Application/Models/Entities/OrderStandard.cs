using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public class OrderStandard : OrderBase
{
    public OrderStandard(Guid identifier, string code, DateTime requestedOn, CustomerStandard customer, List<ItemStandard> items) : base(identifier, code, requestedOn, customer, items, TypeOrder.Standard)
    {
    }
}
