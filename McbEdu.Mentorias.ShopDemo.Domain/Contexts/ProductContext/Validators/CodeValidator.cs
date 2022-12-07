using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Validators;

public class CodeValidator : AbstractValidator<Code>
{
    public CodeValidator()
    {
        RuleFor(p => p.ToString()).NotEmpty().NotNull().WithMessage("O código não pode ser nulo");
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Code.MaxValueLength).WithMessage($"O código pode conter até {Code.MaxValueLength} caracteres");
    }
}
