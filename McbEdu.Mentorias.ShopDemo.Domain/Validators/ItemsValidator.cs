using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class ItemsValidator : AbstractValidator<List<ItemStandard>>
{
    public ItemsValidator(AbstractValidator<ItemStandard> uniqueItemValidator) 
    {
        RuleFor(p => p.ToArray()).Custom((information, context) =>
        {
            if (information.Length < 1)
            {
                context.AddFailure("A listagem de itens não pode ser nula.");
            }

            bool hasErrorMessageWithNotValidSequencialValue = false;
            for (int i = 0; i < information.Length; i++)
            {


                if (i + 1 < information.Length)
                {
                    if (information.Where(p => p.Sequence == (i + 1)).Any() == false && hasErrorMessageWithNotValidSequencialValue == false)
                    {
                        context.AddFailure($"Os itens não possuem valor sequenciais válidos.");
                        hasErrorMessageWithNotValidSequencialValue = true;
                    }
                }

                var productValidation = uniqueItemValidator.Validate(information[i]);
                foreach (var errorItem in productValidation.Errors)
                {
                    context.AddFailure($"O item de sequencial {information[i].Sequence}. {errorItem.ErrorMessage}");
                }
            }

            
        });
    }
}
