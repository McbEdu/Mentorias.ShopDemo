using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Validators;

public class QuantityValidator : AbstractValidator<Quantity>
{
    public QuantityValidator()
    {
        RuleFor(p => p.GetValue()).GreaterThanOrEqualTo(Quantity.MinOrEqualValue).WithMessage($"É necessária que a quantidade seja maior ou igual a {Quantity.MinOrEqualValue} unidade(s)");
    }
}
