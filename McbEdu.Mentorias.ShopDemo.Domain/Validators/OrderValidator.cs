using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class OrderValidator : AbstractValidator<OrderStandard>
{
    public OrderValidator(AbstractValidator<CustomerStandard> customerValidator)
    {
    }
}
