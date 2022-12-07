using FluentValidation;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

public struct Name
{
    // Properties
    private string Value { get; set; }

    // Definitions
    public static int MaxNameLength = 50;

    public Name(string value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<Name> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value;
    }
}
