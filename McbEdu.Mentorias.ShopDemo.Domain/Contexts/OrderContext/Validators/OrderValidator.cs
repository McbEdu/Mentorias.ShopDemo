using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Validators;

public class OrderValidator : AbstractValidator<OrderBase>
{
    public OrderValidator(AbstractValidator<CustomerBase> customerValidator, AbstractValidator<List<ItemBase>> itemRangeValidator, AbstractValidator<Code> codeValidator)
    {
        RuleFor(p => p.Code).SetValidator(codeValidator);
        RuleFor(p => p.Customer).SetValidator(customerValidator);
        RuleFor(p => p.Items).SetValidator(itemRangeValidator);
    }
}
