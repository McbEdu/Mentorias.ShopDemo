using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class BirthDateValidator : AbstractValidator<BirthDate>
{
    public BirthDateValidator()
    {
        RuleFor(p => p.GetValue()).LessThan(BirthDate.MinimumBirthdate).WithMessage("A data de nascimento precisa ser menor que o horário atual");
        RuleFor(p => p.GetValue()).Custom((information, context) =>
        {
            if (information == DateTime.MinValue)
            {
                context.AddFailure("A data de nascimento não pode ser nula ou vazia.");
            }
        });
    }
}
