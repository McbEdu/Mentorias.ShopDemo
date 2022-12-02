using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class OrderValidator : AbstractValidator<OrderStandard>
{
    private static int MaxLengthCodeOrder = 150;

    public OrderValidator(AbstractValidator<CustomerStandard> customerValidator, AbstractValidator<List<ItemStandard>> itemsValidator)
    {
        RuleFor(p => p.Code.Length).LessThanOrEqualTo(MaxLengthCodeOrder).WithMessage($"O código do pedido pode conter até {MaxLengthCodeOrder} caracteres.");
        RuleFor(p => p.Customer).SetValidator(customerValidator);
        RuleFor(p => p.Items).SetValidator(itemsValidator);
    }
}
