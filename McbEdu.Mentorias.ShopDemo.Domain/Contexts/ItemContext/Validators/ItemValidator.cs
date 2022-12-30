using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Validators;

public class ItemValidator : AbstractValidator<ItemBase>
{
    private static int MaxLengthDescription = 150;

    public ItemValidator(AbstractValidator<UnitaryValue> unitaryValueValidator, AbstractValidator<Quantity> quantityValidator, 
        AbstractValidator<ProductBase> productValidator)
    {
        RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage("A descrição do item não pode ser nula");
        RuleFor(p => p.Description.Length).LessThanOrEqualTo(MaxLengthDescription).WithMessage($"A descrição deve possuir até {MaxLengthDescription} caracteres");
        RuleFor(p => p.Product).SetValidator(productValidator);
        RuleFor(p => p.Quantity).SetValidator(quantityValidator);

        RuleFor(p => p.UnitaryValue).SetValidator(unitaryValueValidator);
    }
}
