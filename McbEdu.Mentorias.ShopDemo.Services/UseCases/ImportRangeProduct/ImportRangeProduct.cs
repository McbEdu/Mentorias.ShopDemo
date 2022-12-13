using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportRangeProduct;

public class ImportRangeProductUseCase : IUseCase<List<ImportProductUseCaseInput>>
{
    private readonly IProductService _productService;
    private readonly IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> _adapter;
    private readonly IUnitOfWork _unitOfWork;

    public ImportRangeProductUseCase(IProductService productService, IAdapter<ImportProductUseCaseInput, 
        ImportProductServiceInput> adapter, IUnitOfWork unitOfWork)
    {
        _productService = productService;
        _adapter = adapter;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(List<ImportProductUseCaseInput> useCaseInput)
    {
        return await _unitOfWork.ExecuteAsync(( async () => 
        {
            foreach (var eachProductUseCaseInput in useCaseInput)
            {
                var importProductResult = await _productService.ImportProductAsync(_adapter.Adapt(eachProductUseCaseInput));
                if (importProductResult == false)
                {
                    return false;
                }
            }

            return true;

        }));
    }
}
