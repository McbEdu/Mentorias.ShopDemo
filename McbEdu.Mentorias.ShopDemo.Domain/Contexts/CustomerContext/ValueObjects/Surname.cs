using FluentValidation;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

public struct Surname
{
    // Properties
    private string Value { get; set; }

    // Definitions
    public static int MaxSurnameLength = 150;

    public Surname(string value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<Surname> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value;
    }
}
