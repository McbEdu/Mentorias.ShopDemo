using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

public struct Code
{
    // Properties
    private string Value { get; set; }

    // Definitions
    public static int MaxValueLength = 150;

    public Code(string value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<Code> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value;
    }
}
