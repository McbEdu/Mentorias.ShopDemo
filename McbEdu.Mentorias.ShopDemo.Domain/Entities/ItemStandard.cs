namespace McbEdu.Mentorias.ShopDemo.Domain.Entities;

public class ItemStandard
{
    public Guid Identifier { get; private set; }
    public string Description { get; private set; }
    public int Sequence { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitaryValue { get; private set; }
    public ProductStandard ProductStandard { get; private set; }

    public ItemStandard(Guid identifier, string description, int sequence, int quantity, ProductStandard productStandard, decimal unitaryValue)
    {
        Identifier = identifier;
        Description = description;
        Sequence = sequence;
        Quantity = quantity;
        ProductStandard = productStandard;
        UnitaryValue = unitaryValue;
    }
}
