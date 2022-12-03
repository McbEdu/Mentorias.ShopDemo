using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class CustomerValidator : AbstractValidator<CustomerStandard>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("O nome do cliente não pode ser nulo.");
        RuleFor(p => p.Surname).NotNull().NotEmpty().WithMessage("O sobrenome do cliente não pode ser nulo.");
        RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("O email do cliente não pode ser nulo.");
        RuleFor(p => p.Name.Length).LessThanOrEqualTo(50).WithMessage("O nome do cliente precisa ter até 50 caracteres.");
        RuleFor(p => p.Surname.Length).LessThanOrEqualTo(150).WithMessage("O sobrenome do cliente precisa ter até 150 caracteres.");
        RuleFor(p => p.Email.Length).LessThanOrEqualTo(256).WithMessage("O email do cliente precisa ter até 256 caracteres.");
        RuleFor(p => p.BirthDate).Custom((information, custom) =>
        {
            if (information > DateTime.UtcNow)
            {
                custom.AddFailure(new FluentValidation.Results.ValidationFailure("Data de Nascimento", "A data de nascimento precisa ser menor ou igual à data atual."));
            }
        });
    }
}
