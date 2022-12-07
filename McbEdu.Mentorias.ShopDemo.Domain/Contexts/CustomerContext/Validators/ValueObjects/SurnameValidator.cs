using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class SurnameValidator : AbstractValidator<Surname>
{
    public SurnameValidator()
    {
        RuleFor(p => p.ToString().Length).NotEmpty().NotNull().WithMessage("O sobrenome não pode ser nulo ou vazio.");
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Surname.MaxSurnameLength).WithMessage($"O sobrenome precisa conter até {Surname.MaxSurnameLength} caracteres.");
    }
}
