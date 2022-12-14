using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class BirthDateValidator : AbstractValidator<BirthDate>
{
    public BirthDateValidator()
    {
        RuleFor(p => p.GetValue()).LessThan(BirthDate.MinimumBirthdate).WithMessage("A data de nascimento precisa ser menor que o horário atual");
    }
}
