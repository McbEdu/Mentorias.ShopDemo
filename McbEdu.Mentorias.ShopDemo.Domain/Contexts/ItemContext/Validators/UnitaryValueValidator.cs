using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Validators;

public class UnitaryValueValidator : AbstractValidator<UnitaryValue>
{
    public UnitaryValueValidator()
    {
        RuleFor(p => p.GetValue()).LessThan(UnitaryValue.MinOrEqualValue).WithMessage($"O valor unitário precisa ser maior ou igual que {UnitaryValue.MinOrEqualValue}");
    }
}
