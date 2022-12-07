
using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Validators;

public class ItemRangeValidator : AbstractValidator<List<ItemBase>>
{
    public ItemRangeValidator(AbstractValidator<ItemBase> itemValidator)
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
                if ((i + 1) >= (information.Length - 1))
                {
                    if (information.Where(p => p.Sequence == (i + 1)).Any() == false && hasErrorMessageWithNotValidSequencialValue == false)
                    {
                        context.AddFailure($"Os itens não possuem valor sequenciais válidos.");
                        hasErrorMessageWithNotValidSequencialValue = true;
                    }
                }

                var productValidation = itemValidator.Validate(information[i]);
                foreach (var errorItem in productValidation.Errors)
                {
                    context.AddFailure($"O item de sequencial {information[i].Sequence}. {errorItem.ErrorMessage}");
                }
            }
        });
    }
}
