using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Validators;

public class CodeValidator : AbstractValidator<Code>
{
    public CodeValidator()
    {
        RuleFor(p => p.ToString().Length).NotEqual(0).WithMessage("O código não pode ser nulo ou vazio");
        RuleFor(p => p.ToString()).Custom((information, context) =>
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
                    context.AddFailure(new ValidationFailure("", "O código não pode conter apenas espaços em branco"));
                }
            }
        });
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Code.MaxValueLength).WithMessage($"O código pode conter até {Code.MaxValueLength} caracteres");
    }
}
