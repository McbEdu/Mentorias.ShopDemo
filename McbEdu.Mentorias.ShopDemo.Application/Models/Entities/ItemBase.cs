using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public abstract class ItemBase
{
    public int Sequence { get; private set; }
    public ProductBase Product { get; private set; }
    public string Description { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitaryValue { get; private set; }
    public TypeItem TypeItem { get; init; }

    protected ItemBase(int sequence, ProductBase product, string description, int quantity, decimal unitaryValue, TypeItem typeItem)
    {
        Console.WriteLine(description);
        Console.WriteLine(quantity.ToString());
        Sequence = sequence;
        Product = product;
        Description = description;
        Quantity = quantity;
        UnitaryValue = unitaryValue;
        TypeItem = typeItem;
    }

    public void ChangeSequece(int sequence)
    {
        Sequence = sequence;
    }

    public void ChangeProduct(ProductBase product)
    {
        Product = product;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }

    public void ChangeQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public void ChangeUnitaryValue(decimal unitaryValue)
    {
        UnitaryValue = unitaryValue;
    }
}
