using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterProductStandardToProductDTO : IAdapter<Product, ProductStandard>
{
    public Product Adapt(ProductStandard adapter)
    {
        return new Product()
        {
            Code = adapter.Code,
            Description = adapter.Description,
            Identifier = adapter.Identifier
        };
    }
}
