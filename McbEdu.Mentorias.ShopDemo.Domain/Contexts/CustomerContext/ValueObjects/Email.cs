using FluentValidation;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

public struct Email
{
    // Properties
    private string Value { get; set; }

    // Definitions
    public static int MaxValueLength = 256;

    public Email(string value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<Email> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value;
    }
}
