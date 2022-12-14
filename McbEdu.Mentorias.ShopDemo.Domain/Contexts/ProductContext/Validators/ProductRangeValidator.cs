using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Validators;

public class ProductRangeValidator : AbstractValidator<List<ProductBase>>
{
    public ProductRangeValidator(AbstractValidator<ProductBase> productValidator)
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
                    if (information[i].Code.ToString() == information[j].Code.ToString())
                    {
                        custom.AddFailure(new FluentValidation.Results.ValidationFailure("Produto", $"Os produtos de indexador {i + 1} e {j + 1} possuem mesmo código {information[i].Code}. Não foi possível realizar a importação"));
                    }
                }
            }
        });
    }
}
