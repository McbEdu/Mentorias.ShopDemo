using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public class ProductStandard : ProductBase
{
    public ProductStandard(Guid identifier, string code, string description, TypeProduct typeProduct) : base(identifier, code, description, TypeProduct.Standard)
    {
    }
}
