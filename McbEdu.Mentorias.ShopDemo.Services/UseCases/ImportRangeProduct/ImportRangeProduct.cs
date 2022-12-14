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
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public ImportRangeProductUseCase(IProductService productService, IAdapter<ImportProductUseCaseInput, 
        ImportProductServiceInput> adapter, IUnitOfWork unitOfWork,
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _productService = productService;
        _adapter = adapter;
        _unitOfWork = unitOfWork;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteAsync(List<ImportProductUseCaseInput> useCaseInput)
    {
        return await _unitOfWork.ExecuteAsync(( async () => 
        {
            for (int i = 0; i < useCaseInput.Count; i++)
            {
                var importProductResult = await _productService.ImportProductAsync(_adapter.Adapt(useCaseInput[i]));
                if (importProductResult.Item1 == false)
                {
                    var newResultValidation = new List<NotificationItem>();

                    foreach (var validationResult in importProductResult.Item2)
                    {
                        newResultValidation.Add(new NotificationItem($"Produto de indexador {(i + 1)}. {validationResult.Message}"));
                    }

                    _notificationPublisher.AddNotifications(newResultValidation);

                    return false;
                }
            }

            return true;

        }));
    }
}
