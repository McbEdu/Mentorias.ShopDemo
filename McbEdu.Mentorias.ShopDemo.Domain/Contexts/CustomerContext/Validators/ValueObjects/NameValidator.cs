using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(p => p.ToString().Length).NotEmpty().NotNull().WithMessage("O nome não pode ser nulo ou vazio.");
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Name.MaxNameLength).WithMessage($"O nome precisa conter até {Name.MaxNameLength} caracteres.");
    }
}
