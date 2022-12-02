using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class ProductValidator : AbstractValidator<ProductStandard>
{
    private static int MaxCodeLength = 150;
    private static int MaxDescriptionLength = 500;

    public ProductValidator()
    {
        RuleFor(p => p.Code.Length).LessThanOrEqualTo(MaxCodeLength).WithMessage($"O código precisa ter até {MaxCodeLength} caracteres.");
        RuleFor(p => p.Description.Length).LessThanOrEqualTo(MaxDescriptionLength).WithMessage($"A descrição precisa ter até {MaxDescriptionLength} caracteres.");
    }
}
