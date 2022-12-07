using FluentValidation;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

public struct Quantity
{
    // Properties
    private int Value { get; set; }

    // Definitions
    public static int MinOrEqualValue = 1;

    public Quantity(int value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<Quantity> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public int GetValue()
    {
        return Value;
    }
}
