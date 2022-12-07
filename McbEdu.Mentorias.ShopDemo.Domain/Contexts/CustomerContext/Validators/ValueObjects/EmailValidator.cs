using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(p => p.ToString().Length).NotEmpty().NotNull().WithMessage("O email não pode ser nulo ou vazio.");
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Email.MaxValueLength).WithMessage($"O email precisa conter até {Email.MaxValueLength} caracteres.");
    }
}