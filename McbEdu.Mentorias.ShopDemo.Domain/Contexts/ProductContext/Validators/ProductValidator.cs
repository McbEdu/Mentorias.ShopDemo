using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Validators;

public class ProductValidator : AbstractValidator<ProductBase>
{
    public ProductValidator(AbstractValidator<Code> codeValidator)
    {
        RuleFor(p => p.Code).SetValidator(codeValidator);
        RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("A descrição não pode ser nula ou vazia.");
        RuleFor(p => p.Description.Length).LessThanOrEqualTo(500).WithMessage("A descrição pode conter até 500 caracteres");
    }
}
