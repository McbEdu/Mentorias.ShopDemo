using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class CustomerRangeValidator : AbstractValidator<List<CustomerStandard>>
{
    public CustomerRangeValidator(AbstractValidator<CustomerStandard> customerValidator)
    {
        RuleFor(p => p.ToList()).Custom((information, custom) =>
        {
            int value = 0;
            foreach (var item in information)
            {
                value++;
                var validationResult = customerValidator.Validate(item);

                if (validationResult.IsValid == true)
                {
                    continue;
                }


                foreach (var validationFailure in validationResult.Errors)
                {
                    if (item.Email.Length < 256)
                    {
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Cliente", $"Cliente {value} com email igual a {item.Email}. {validationResult.Errors}"));
                    }
                    else
                    {
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Cliente", $"Cliente {value} com email inválido. {validationResult.Errors}"));
                    }
                }
            }

            var customersRange = information.ToArray();

            for (int i = 0; i < customersRange.Length; i++)
            {
                for (int j = i + 1; j < customersRange.Length; j++)
                {
                    if (customersRange[i].Email == customersRange[j].Email)
                    {
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Cliente", $"Os clientes com email igual a {customersRange[j].Email} de indexadores {i + 1} e {j + 1} não pode ter mesmas credenciais."));
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Cliente", $"A lista de clientes é inválida! Não é possível que dois clientes tenham o mesmo email."));
                    }
                }
            }
        });
    }
}
