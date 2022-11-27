using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;

public class OrderValidator : AbstractValidator<OrderBase>
{
    public OrderValidator()
    {
        RuleFor(p => p.Code.Length).LessThanOrEqualTo(150).WithMessage(p => $"O código do pedido deve conter até 150 caracteres.");
        RuleFor(c => c.RequestedOn).Custom((information, context) =>
        {
            DateTime dateTimeParsed;
            var dateTime = DateTime.TryParse(information.ToString(), out dateTimeParsed);
            if (dateTime == false)
            {
                context.AddFailure("", "A data do pedido precisa ser válida!");
            }
            else
            {
                if (dateTimeParsed > DateTime.Now)
                {
                    context.AddFailure("", "A data do pedido não pode ser futura.");
                }
            }
        });


        RuleFor(p => p.Items).Custom((information, context) =>
        {
            var informationArray = information.ToArray();



            if (informationArray.Length < 1)
            {
                context.AddFailure("Pedido", $"O pedido tem que conter pelo menos um item.");
            }

            for (int i = 0; i < informationArray.Length; i++)
            {
                if (informationArray.Where(p => p.Sequence == (i + 1)).Any() == false)
                {
                    context.AddFailure("Pedido", $"Os itens precisam ter valor sequencial válido.");
                }

                if (informationArray.Where(p => p.Sequence < 0).Any() == true)
                {
                    context.AddFailure("Pedido", $"Os itens precisam ter valor sequencial válido.");
                }

                if (informationArray[i].Product.Code.Length > 150)
                {
                    context.AddFailure("Pedido", $"O produto do item de sequência {informationArray[i].Sequence} precisa conter código com até 150 caracteres.");
                }

                if (informationArray[i].Product.Description.Length > 500)
                {
                    context.AddFailure("Pedido", $"O produto do item de sequência {informationArray[i].Sequence} precisa conter uma descrição com até 500 caracteres.");
                }
            }

            for (int i = 0; i < informationArray.Length; i++)
            {
                if (informationArray[i].Quantity < 1)
                {
                    context.AddFailure("Pedido", $"Item {informationArray[i].Sequence}. Não possui quantidade válida.");
                }

                if (informationArray[i].UnitaryValue <= 0)
                {
                    context.AddFailure("Pedido", $"Item {informationArray[i].Sequence}. não possui um valor unitário válido.");
                }
            }
        });
    }
}
