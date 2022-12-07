using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;

public abstract class ItemBase
{
    public Guid Identifier { get; init; }
    public int Sequence { get; private set; }
    public Quantity Quantity { get; private set; }
    public string Description { get; private set; }
    public UnitaryValue UnitaryValue { get; private set; }
    public TypeItem TypeItem { get; init; }

    protected ItemBase(Guid identifier, int sequence, Quantity quantity, string description, UnitaryValue unitaryValue, TypeItem typeItem)
    {
        Identifier = identifier;
        Sequence = sequence;
        Quantity = quantity;
        Description = description;
        UnitaryValue = unitaryValue;
        TypeItem = typeItem;
    }
}
