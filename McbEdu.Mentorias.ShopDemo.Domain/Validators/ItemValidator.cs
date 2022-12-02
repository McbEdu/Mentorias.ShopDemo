using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class ItemValidator : AbstractValidator<ItemStandard>
{
    private static int MaxLengthDescription = 150;
    private static int MinQuantity = 1;
    private static int MinUnitaryValue = 0;

    public ItemValidator(AbstractValidator<ProductStandard> productValidator)
    {
        RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage("A descrição do item não pode ser nula.");

        RuleFor(p => p.Description.Length)
            .LessThanOrEqualTo(MaxLengthDescription).WithMessage($"A descrição deve possuir até {MaxLengthDescription} caracteres.");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(MinQuantity).WithMessage($"A quantidade de produtos deve ser pelo menos de {MinQuantity} unidades.");

        RuleFor(p => p.ProductStandard).SetValidator(productValidator);

        RuleFor(p => p.UnitaryValue)
            .GreaterThanOrEqualTo(MinUnitaryValue).WithMessage($"O valor unitário deve ser pelos menos de {MinUnitaryValue}.");
    }
}
