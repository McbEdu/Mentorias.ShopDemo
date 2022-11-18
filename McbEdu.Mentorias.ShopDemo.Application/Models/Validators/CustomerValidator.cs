using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class CustomerValidator : AbstractValidator<CustomerBase>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Identifier.ToString()).Matches(@"^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$").WithMessage("O identificador precisa estar no padrão esperado.");

        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("O nome do cliente não pode ser nulo ou vazio.");
        RuleFor(c => c.Name.Length).GreaterThan(2).WithMessage("O nome do cliente deve ter três caracteres ou mais.");
        RuleFor(c => c.Name.Length).LessThan(30).WithMessage("O nome do cliente deve ter menos que 30 caracteres.");
        RuleFor(c => c.Name).Custom((information, context) =>
        {
            foreach (var character in information)
            {
                if (char.IsLetter(character) == false && information.ToLower().Contains("é") == false && information.ToLower().Contains("á") == false && char.IsWhiteSpace(character) == false)
                {
                    context.AddFailure($"O nome do cliente deve conter apenas caracteres adequados.");
                    return;
                }
            }
        });

        RuleFor(c => c.Surname).NotEmpty().NotNull().WithMessage("O sobrenome do cliente não pode ser nulo ou vazio.");
        RuleFor(c => c.Surname.Length).GreaterThan(3).WithMessage("O sobrenome do cliente deve ter quatro caracteres ou mais.");
        RuleFor(c => c.Surname.Length).LessThan(50).WithMessage("O sobrenome do cliente deve ter menos que 50 caracteres.");
        RuleFor(c => c.Surname).Custom((information, context) =>
        {
            foreach (var character in information)
            {
                if (char.IsLetter(character) == false && information.ToLower().Contains("é") == false && information.ToLower().Contains("á") == false && char.IsWhiteSpace(character) == false)
                {
                    context.AddFailure($"O sobrenome do cliente deve conter apenas caracteres adequados.");
                    return;
                }
            }
        });

        RuleFor(c => c.Email).EmailAddress().WithMessage("O email precisa estar em um formato válido!");

        RuleFor(c => c.Birthday).Custom((information, context) =>
        {
            if (information > DateTime.Now || information == DateTime.UnixEpoch)
            {
                context.AddFailure($"A data de aniversário do cliente necessita ser válida!");
            }
        });
    }
}
