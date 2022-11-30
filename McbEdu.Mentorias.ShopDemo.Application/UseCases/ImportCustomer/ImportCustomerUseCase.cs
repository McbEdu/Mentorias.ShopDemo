using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer;

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
        if (await _customerService.VerifyCustomerIsRegistered(_adapter.Adapt(useCaseInput)) == false)
        {
            await _customerService.ImportCustomerAsync(_adapter.Adapt(useCaseInput));
            return true;
        }
        else
        {
            _notificationPublisher.AddNotification(new NotificationItem("O cliente já possui uma importação!"));
            return false;
        }
    }
}
