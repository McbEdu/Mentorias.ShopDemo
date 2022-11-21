using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public class ItemStandard : ItemBase
{
    public ItemStandard(int sequence, ProductBase product, string description, int quantity, decimal unitaryValue) : base(sequence, product, description, quantity, unitaryValue, TypeItem.Standard)
    {
    }
}
