using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class ProductValidator : AbstractValidator<ProductBase>
{
    private int CodeMaxLength = 150;
    private int DescriptionMaxLength = 500;

    public ProductValidator()
    {
        RuleFor(p => p.Code.Length).LessThanOrEqualTo(CodeMaxLength).WithMessage(c => $"O código do produto necessita ter até {CodeMaxLength} caracteres.");
        RuleFor(p => p.Description.Length).LessThanOrEqualTo(DescriptionMaxLength).WithMessage(c => $"A descrição do produto necessita ter até {DescriptionMaxLength} caracteres.");
    }
}
