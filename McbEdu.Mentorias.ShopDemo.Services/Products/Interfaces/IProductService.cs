using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;

public interface IProductService
{
    Task<bool> ImportProductAsync(ImportProductServiceInput input);
    Task<bool> VerifyProductIsRegisteredAsync(ImportProductServiceInput input);
    Task<bool> VerifyProductIsValidAsync(ImportProductServiceInput input);
    Task<bool> VerifyProductRangeIsValidAsync(List<ImportProductServiceInput> input);
}
