using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Products.Adapters;

public class AdapterProductStandardToProductDataTransfer : IAdapter<Product, ProductStandard>
{
    public Product Adapt(ProductStandard adapt)
    {
        return new Product()
        {
            Identifier = adapt.Identifier,
            Description = adapt.Description,
            Code = adapt.Code
        };
    }

    public ProductStandard Adapt(Product adapter)
    {
        throw new NotImplementedException();
    }
}
