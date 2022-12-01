using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class ProductValidator : AbstractValidator<ProductStandard>
{
    public ProductValidator()
    {
        RuleFor(p => p.Code.Length).LessThanOrEqualTo(150).WithMessage("O código precisa ter até 150 caracteres.");
        RuleFor(p => p.Description.Length).LessThanOrEqualTo(500).WithMessage("A descrição precisa ter até 500 caracteres.");
    }
}
