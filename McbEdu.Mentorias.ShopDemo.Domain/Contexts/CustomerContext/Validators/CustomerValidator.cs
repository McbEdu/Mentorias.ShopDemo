using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Validators;

public class CustomerValidator : AbstractValidator<CustomerStandard>
{
    public CustomerValidator(AbstractValidator<Name> nameValidator, AbstractValidator<Surname> surnameValidator, AbstractValidator<Email> emailValidator, AbstractValidator<BirthDate> birthDateValidator)
    {
        RuleFor(p => p.Name).SetValidator(nameValidator);
        RuleFor(p => p.Surname).SetValidator(surnameValidator);
        RuleFor(p => p.Email).SetValidator(emailValidator);
        RuleFor(p => p.BirthDate).SetValidator(birthDateValidator);
        RuleFor(p => (int)p.TypeCustomer).InclusiveBetween((int)TypeCustomer.Standard, (int)TypeCustomer.Standard).WithMessage("O tipo do cliente precisa ser válido!");
    }
}
