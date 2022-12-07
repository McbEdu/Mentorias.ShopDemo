using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities;

public class ProductStandard : ProductBase
{
    public ProductStandard(Guid identifier, Code code, string description) : base(identifier, code, description, TypeProduct.Standard)
    {
    }
}
