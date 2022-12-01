using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportRangeProduct;

public class ImportRangeProductUseCase : IUseCase<List<ImportProductUseCaseInput>>
{
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IProductService _productService;
    private readonly IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> _adapter;

    public ImportRangeProductUseCase(INotificationPublisher<NotificationItem> notificationPublisher,
        IProductService productService, IAdapter<ImportProductUseCaseInput, ImportProductServiceInput> adapter)
    {
        _notificationPublisher = notificationPublisher;
        _productService = productService;
        _adapter = adapter;
    }

    public async Task<bool> ExecuteAsync(List<ImportProductUseCaseInput> useCaseInput)
    {
        bool allNotRegisteredInDatabase = true;
        foreach (var eachUseCaseInput in useCaseInput)
        {
            if (await _productService.VerifyProductIsRegisteredAsync(_adapter.Adapt(eachUseCaseInput)) == true)
            {
                allNotRegisteredInDatabase = false;
            }
            break;
        }

        if (allNotRegisteredInDatabase == true)
        {
            var productServiceInputList = new List<ImportProductServiceInput>();
            foreach (var uniqueUseCaseInput in useCaseInput)
            {
                productServiceInputList.Add(_adapter.Adapt(uniqueUseCaseInput));
            }

            if (await _productService.VerifyProductRangeIsValidAsync(productServiceInputList) == true)
            {
                foreach (var eachUseCaseInput in useCaseInput)
                {
                    await _productService.ImportProductAsync(_adapter.Adapt(eachUseCaseInput));
                }
                return true;
            }

            return false;
        }
        else
        {
            _notificationPublisher.AddNotification(new NotificationItem("Os produtos já possuem importação!"));

            var productServiceInputList = new List<ImportProductServiceInput>();
            foreach (var uniqueUseCaseInput in useCaseInput)
            {
                productServiceInputList.Add(_adapter.Adapt(uniqueUseCaseInput));
            }

            await _productService.VerifyProductRangeIsValidAsync(productServiceInputList);

            return false;
        }
    }
}
