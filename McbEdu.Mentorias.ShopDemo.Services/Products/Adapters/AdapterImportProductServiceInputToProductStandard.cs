using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Products.Adapters;

public class AdapterImportProductServiceInputToProductStandard : IAdapter<ImportProductServiceInput, ProductStandard>
{
    public ImportProductServiceInput Adapt(ProductStandard adapt)
    {
        throw new NotImplementedException();
    }

    public ProductStandard Adapt(ImportProductServiceInput adapter)
    {
        return new ProductStandard(Guid.NewGuid(), adapter.Code, adapter.Description);
    }
}
