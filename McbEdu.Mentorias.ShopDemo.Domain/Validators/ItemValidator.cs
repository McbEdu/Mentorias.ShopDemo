using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Domain.Validators;

public class ItemValidator : AbstractValidator<ItemStandard>
{
    public ItemValidator(AbstractValidator<ProductStandard> productValidator)
    {
    }
}
