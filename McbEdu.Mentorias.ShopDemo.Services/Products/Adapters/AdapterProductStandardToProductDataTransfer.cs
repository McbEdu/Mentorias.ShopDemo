using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Services.Products.Adapters;

public class AdapterProductStandardToProductDataTransfer : IAdapter<Product, ProductBase>
{
    public Product Adapt(ProductBase adapt)
    {
        return new Product()
        {
            Identifier = adapt.Identifier,
            Description = adapt.Description,
            Code = adapt.Code.ToString()
        };
    }

    public ProductBase Adapt(Product adapter)
    {
        throw new NotImplementedException();
    }
}
