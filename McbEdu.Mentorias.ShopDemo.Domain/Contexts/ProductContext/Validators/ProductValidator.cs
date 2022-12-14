using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Validators;

public class ProductValidator : AbstractValidator<ProductBase>
{
    public ProductValidator(AbstractValidator<Code> codeValidator)
    {
        RuleFor(p => p.Code).SetValidator(codeValidator);
        RuleFor(p => p.Description.Length).NotEqual(0).WithMessage("A descrição não pode ser nula ou vazia");
        RuleFor(p => p.Description.ToString()).Custom((information, context) =>
        {
            if (information.Length > 0)
            {
                bool hasLetterDifferentOfWhiteSpace = false;
                foreach (var character in information)
                {
                    if (char.IsWhiteSpace(character) is false)
                    {
                        hasLetterDifferentOfWhiteSpace = true;
                    }
                }

                if (hasLetterDifferentOfWhiteSpace == false)
                {
                    context.AddFailure(new ValidationFailure("", "A descrição não pode conter apenas espaços em branco"));
                }
            }
        });
        RuleFor(p => p.Description.Length).LessThanOrEqualTo(500).WithMessage("A descrição pode conter até 500 caracteres");
    }
}
