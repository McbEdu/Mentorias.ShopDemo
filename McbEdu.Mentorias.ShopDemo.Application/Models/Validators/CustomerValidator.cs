using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class CustomerValidator : AbstractValidator<CustomerBase>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Identifier.ToString()).Matches(@"^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$").WithMessage("O identificador precisa estar no padrão esperado.");

        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("O nome do cliente não pode ser nulo ou vazio.").WithName(p => p.Name);
        RuleFor(c => c.Name.Length).LessThan(51).WithMessage("O nome do cliente deve ter menos que 51 caracteres.").WithName(p => p.Name);
        RuleFor(c => c.Name).Custom((information, context) =>
        {
            foreach (var character in information)
            {
                if (char.IsLetter(character) == false && information.ToLower().Contains("é") == false && information.ToLower().Contains("á") == false && char.IsWhiteSpace(character) == false)
                {
                    context.AddFailure(information.ToString(),$"O nome do cliente deve conter apenas caracteres adequados.");
                    return;
                }
            }
        });

        RuleFor(c => c.Surname).NotEmpty().NotNull().WithMessage("O sobrenome do cliente não pode ser nulo ou vazio.").WithName(p => p.Surname);
        RuleFor(c => c.Surname.Length).LessThan(151).WithMessage("O sobrenome do cliente deve ter menos que 151 caracteres.").WithName(p => p.Surname);
        RuleFor(c => c.Surname).Custom((information, context) =>
        {
            foreach (var character in information)
            {
                if (char.IsLetter(character) == false && information.ToLower().Contains("é") == false && information.ToLower().Contains("á") == false && char.IsWhiteSpace(character) == false)
                {
                    context.AddFailure(information, $"O sobrenome do cliente deve conter apenas caracteres adequados.");
                    return;
                }
            }
        });

        RuleFor(c => c.Email.Length).LessThan(151).WithMessage("O sobrenome do cliente deve ter menos que 151 caracteres.").WithName(p => p.Email);
        RuleFor(c => c.Email).EmailAddress().WithMessage("O email precisa estar em um formato válido!").WithName(p => p.Email);

        RuleFor(c => c.Birthday).Custom((information, context) =>
        {
            if (information > DateTime.Now || information == DateTime.UnixEpoch)
            {
                context.AddFailure(information.ToString(), $"A data de aniversário do cliente necessita ser válida!");
            }
        });
    }
}
