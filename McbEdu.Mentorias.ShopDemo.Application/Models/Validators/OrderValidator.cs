using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class OrderValidator : AbstractValidator<OrderBase>
{
    public OrderValidator()
    {
        RuleFor(p => p.Code.Length).LessThanOrEqualTo(150).WithMessage(p => $"O código do pedido deve conter até 150 caracteres.");
        RuleFor(p => p.Items).Custom((information, context) =>
        {
            var informationArray = information.ToArray();

            if (informationArray.Length < 1)
            {
                context.AddFailure("Pedido", $"O pedido tem que conter pelo menos um item.");
            }

            for(int i = 0; i < informationArray.Length; i++)
            {
                if (informationArray.Where(p => p.Sequence == (i + 1)).Any() == false)
                {
                    context.AddFailure("Pedido", $"O item de descrição igual a {informationArray[i].Description} não possui valor sequencial válido.");
                }

                if (informationArray[i].Quantity < 1)
                {
                    context.AddFailure("Pedido", $"O item de descrição igual a {informationArray[i].Description} não quantidade válida.");
                }

                if (informationArray[i].UnitaryValue <= 0)
                {
                    context.AddFailure("Pedido", $"O item de descrição igual a {informationArray[i].Description} não possui um valor unitário válido.");
                }
            }
        });
    }
}
