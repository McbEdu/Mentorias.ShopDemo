using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class CustomerValidator : AbstractValidator<CustomerBase>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(c => $"O nome do cliente não pode ser nulo ou vazio.");
        RuleFor(c => c.Name.Length).LessThan(51).WithMessage(c => $"O nome do cliente deve ter até 50 caracteres.");

        RuleFor(c => c.Surname).NotEmpty().NotNull().WithMessage(c => $"O sobrenome do cliente não pode ser nulo ou vazio.");
        RuleFor(c => c.Surname.Length).LessThan(151).WithMessage(c => $"O sobrenome do cliente deve ter até 150 caracteres.");

        RuleFor(c => c.Email.Length).LessThan(256).WithMessage(c => $"O email do cliente deve ter até que 256 caracteres.");

        RuleFor(c => c.Birthday).Custom((information, context) =>
        {
            DateTime dateTimeParsed;
            var dateTime = DateTime.TryParse(information.ToString(), out dateTimeParsed);
            if (dateTime == false)
            {
                context.AddFailure("", "A data de aniversário do cliente precisa ser válida!");
            }

            if (information > DateTime.Now || information == DateTime.UnixEpoch)
            {
                context.AddFailure(information.ToString(), $"A data de aniversário do cliente precisa ser válida.");
            }
        });
    }
}
