using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class ProductRangeValidator : AbstractValidator<List<ProductStandard>>
{
    public ProductRangeValidator(AbstractValidator<ProductStandard> productValidator)
    {
        RuleFor(p => p.ToArray()).Custom((information, custom) =>
        {
            for (int i = 0; i < information.Length; i++)
            {
                var uniqueProductValidation = productValidator.Validate(information[i]);

                if (uniqueProductValidation.IsValid == false)
                {
                    foreach (var validationFailure in uniqueProductValidation.Errors)
                    {
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Produto", $"Produto de indexador {i + 1}. {validationFailure.ErrorMessage}"));
                    }
                }

                for (int j = i + 1; j < information.Length; j++)
                {
                    if (information[i].Code == information[j].Code)
                    {
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Produto", $"Os produtos de indexador {i + 1} e {j + 1} possuem mesmo código {information[i].Code}. Não foi possível realizar a importação."));
                    }
                }
            }
        });
    }
}
