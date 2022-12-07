using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

namespace McbEdu.Mentorias.ShopDemo.Services.Products.Adapters;

public class AdapterImportProductServiceInputToProductStandard : IAdapter<ImportProductServiceInput, ProductBase>
{
    public ImportProductServiceInput Adapt(ProductBase adapt)
    {
        throw new NotImplementedException();
    }

    public ProductBase Adapt(ImportProductServiceInput adapter)
    {
        return new ProductStandard(Guid.NewGuid(), new Code(adapter.Code), adapter.Description);
    }
}
