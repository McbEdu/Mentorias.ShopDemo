using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct;

public class ImportProductUseCase : IUseCase<ImportProductUseCaseInput>
{
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IProductService _productService;
    private readonly IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> _adapter;

    public ImportProductUseCase(INotificationPublisher<NotificationItem> notificationPublisher, IProductService productService,
        IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> adapter)
    {
        _notificationPublisher = notificationPublisher;
        _productService = productService;
        _adapter = adapter;
    }

    public async Task<bool> ExecuteAsync(ImportProductUseCaseInput useCaseInput)
    {
        var adapted = _adapter.Adapt(useCaseInput);

        if (await _productService.VerifyProductIsRegisteredAsync(adapted) == false)
        {
            if (await _productService.VerifyProductIsValidAsync(adapted) == true)
            {
                return await _productService.ImportProductAsync(adapted);
            }

            return false;
        }
        else
        {
            _notificationPublisher.AddNotification(new NotificationItem("O produto já possui uma importação!"));
            return false;
        }
    }
}
