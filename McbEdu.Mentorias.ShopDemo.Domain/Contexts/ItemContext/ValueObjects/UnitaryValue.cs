using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

public struct UnitaryValue
{
    // Properties
    private decimal Value { get; set; }

    // Definitions
    public static int MinOrEqualValue = 0;

    public UnitaryValue(decimal value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<UnitaryValue> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public decimal GetValue()
    {
        return Value;
    }
}
