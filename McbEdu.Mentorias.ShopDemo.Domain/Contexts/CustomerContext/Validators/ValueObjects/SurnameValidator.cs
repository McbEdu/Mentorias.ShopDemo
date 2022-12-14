using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators.ValueObjects;

public class SurnameValidator : AbstractValidator<Surname>
{
    public SurnameValidator()
    {
        RuleFor(p => p.ToString().Length).NotEqual(0).WithMessage("O sobrenome não pode ser nulo ou vazio");
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
                    context.AddFailure(new ValidationFailure("", "O sobrenome não pode conter apenas espaços em branco"));
                }
            }
        });
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Surname.MaxSurnameLength).WithMessage($"O sobrenome precisa conter até {Surname.MaxSurnameLength} caracteres");
    }
}
