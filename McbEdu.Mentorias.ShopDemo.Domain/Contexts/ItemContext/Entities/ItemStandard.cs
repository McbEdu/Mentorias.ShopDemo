using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities;

public class ItemStandard : ItemBase
{
    public ItemStandard(Guid identifier, int sequence, Quantity quantity, string description, UnitaryValue unitaryValue, ProductBase product) 
        : base(identifier, sequence, quantity, description, unitaryValue, product, TypeItem.Standard)
    {
    }
}
