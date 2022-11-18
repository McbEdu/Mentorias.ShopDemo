using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class CustomerValidator : AbstractValidator<CustomerBase>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Identifier.ToString()).Matches(@"^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$").WithMessage("O identificador precisa estar no padrão esperado.");

        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(c => $"O nome do cliente {c.Name} não pode ser nulo ou vazio.");
        RuleFor(c => c.Name.Length).LessThan(51).WithMessage(c => $"O nome do cliente {c.Name} deve ter menos que 51 caracteres.");
        RuleFor(c => c.Name).Custom((information, context) =>
        {
            foreach (var character in information)
            {
                if (char.IsLetter(character) == false && information.ToLower().Contains("é") == false && information.ToLower().Contains("á") == false && char.IsWhiteSpace(character) == false)
                {
                    context.AddFailure(information.ToString(), $"O nome do cliente {information} deve conter apenas caracteres adequados.");
                    return;
                }
            }
        });

        RuleFor(c => c.Surname).NotEmpty().NotNull().WithMessage(c => $"O sobrenome {c.Surname} do cliente {c.Name} não pode ser nulo ou vazio.");
        RuleFor(c => c.Surname.Length).LessThan(151).WithMessage(c => $"O sobrenome {c.Surname} do cliente {c.Name} deve ter menos que 151 caracteres.");
        RuleFor(c => c.Surname).Custom((information, context) =>
        {
            foreach (var character in information)
            {
                if (char.IsLetter(character) == false && information.ToLower().Contains("é") == false && information.ToLower().Contains("á") == false && char.IsWhiteSpace(character) == false)
                {
                    context.AddFailure(information, $"O sobrenome do cliente {information} deve conter apenas caracteres adequados.");
                    return;
                }
            }
        });

        RuleFor(c => c.Email.Length).LessThan(151).WithMessage(c => $"O sobrenome {c.Surname} do cliente {c.Name} deve ter menos que 151 caracteres.");
        RuleFor(c => c.Email).EmailAddress().WithMessage(c => $"O email {c.Email} do cliente {c.Name} precisa estar em um formato válido!");

        RuleFor(c => c.Birthday).Custom((information, context) =>
        {
            if (information > DateTime.Now || information == DateTime.UnixEpoch)
            {
                context.AddFailure(information.ToString(), $"A data de aniversário do cliente {information.ToString("dd/MM/yyyy")} necessita ser válida!");
            }
        });
    }
}
