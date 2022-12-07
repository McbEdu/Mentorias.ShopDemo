using FluentValidation;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

public struct BirthDate
{
    // Properties
    private DateTime Value { get; set; }

    // Definitions
    public static DateTime MinimumBirthdate = DateTime.UtcNow;

    public BirthDate(DateTime value)
    {
        Value = value;
    }

    public bool Validate(AbstractValidator<BirthDate> validator)
    {
        return validator.Validate(this).IsValid;
    }

    public override string ToString()
    {
        return Value.ToString("G");
    }

    public DateTime GetValue()
    {
        return Value;
    }
}
