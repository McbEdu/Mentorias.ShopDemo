using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(p => p.ToString().Length).NotEqual(0).WithMessage("O nome não pode ser nulo ou vazio");
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
                    context.AddFailure(new ValidationFailure("", "O nome não pode conter apenas espaços em branco"));
                }
            }
        });
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Name.MaxNameLength).WithMessage($"O nome precisa conter até {Name.MaxNameLength} caracteres");
    }
}
