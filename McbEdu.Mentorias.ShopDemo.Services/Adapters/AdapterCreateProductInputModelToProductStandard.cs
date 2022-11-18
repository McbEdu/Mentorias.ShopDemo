using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterCreateProductInputModelToProductStandard : IAdapter<ProductStandard, CreateProductInputModel>
{
    public ProductStandard Adapt(CreateProductInputModel adapter)
    {
        return new ProductStandard(Guid.NewGuid(), adapter.Code, adapter.Description);
    }
}
