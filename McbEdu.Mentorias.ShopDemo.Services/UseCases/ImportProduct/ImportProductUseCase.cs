using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportProduct;

public class ImportProductUseCase : IUseCase<ImportProductUseCaseInput>
{
    private readonly IProductService _productService;
    private readonly IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> _adapter;
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public ImportProductUseCase(IProductService productService,
        IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> adapter, IUnitOfWork unitOfWork,
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _productService = productService;
        _adapter = adapter;
        _unitOfWork = unitOfWork;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteAsync(ImportProductUseCaseInput useCaseInput)
    {
        return await _unitOfWork.ExecuteAsync((async () => 
        {
            var response = await _productService.ImportProductAsync(_adapter.Adapt(useCaseInput));

            if (response.Item1 == false)
            {
                _notificationPublisher.AddNotifications(response.Item2);
                return false;
            }

            return true;
        }));
    }
}
