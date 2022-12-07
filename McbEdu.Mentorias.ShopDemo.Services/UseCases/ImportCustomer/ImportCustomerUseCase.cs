using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer;

public class ImportCustomerUseCase : IUseCase<ImportCustomerUseCaseInput>
{
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> _adapter;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public ImportCustomerUseCase(ICustomerService customerService, IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> adapter,
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _adapter = adapter;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteAsync(ImportCustomerUseCaseInput useCaseInput)
    {
        var adapted = _adapter.Adapt(useCaseInput);

        if (await _customerService.VerifyCustomerIsRegistered(adapted) == false)
        {
            if (await _customerService.VerifyCustomerIsValid(adapted) == true)
            {
                await _customerService.ImportCustomerAsync(adapted);
                return true;
            }
            return false;
        }
        else
        {
            _notificationPublisher.AddNotification(new NotificationItem("O cliente já possui uma importação!"));
            return false;
        }
    }
}
