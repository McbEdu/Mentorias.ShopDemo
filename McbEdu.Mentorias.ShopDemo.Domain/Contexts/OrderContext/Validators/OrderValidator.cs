using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Validators;

public class OrderValidator : AbstractValidator<OrderBase>
{
    public OrderValidator(AbstractValidator<CustomerBase> customerValidator, AbstractValidator<Code> codeValidator)
    {
        RuleFor(p => p.Code).SetValidator(codeValidator);
        RuleFor(p => p.Customer).SetValidator(customerValidator);
    }
}
