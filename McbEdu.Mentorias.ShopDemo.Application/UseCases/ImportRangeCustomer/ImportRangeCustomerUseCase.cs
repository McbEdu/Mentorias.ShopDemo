using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportRangeCustomer;

public class ImportRangeCustomerUseCase : IUseCase<List<ImportCustomerUseCaseInput>>
{
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> _adapter;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public ImportRangeCustomerUseCase(ICustomerService customerService, IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> adapter,
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _adapter = adapter;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteAsync(List<ImportCustomerUseCaseInput> useCaseInput)
    {
        bool allNotRegisteredInDatabase = true;
        foreach (var eachUseCaseInput in useCaseInput)
        {
            if (await _customerService.VerifyCustomerIsRegistered(_adapter.Adapt(eachUseCaseInput)) == true)
            {
                allNotRegisteredInDatabase = false;
            }
            break;
        }

        if (allNotRegisteredInDatabase == true)
        {
            var customerServiceListInput = new List<ImportCustomerServiceInput>();
            foreach (var uniqueUseCaseInput in useCaseInput)
            {
                customerServiceListInput.Add(_adapter.Adapt(uniqueUseCaseInput));
            }

            if (await _customerService.VerifyListCustomerIsValid(customerServiceListInput) == true)
            {
                foreach (var eachUseCaseInput in useCaseInput)
                {
                    await _customerService.ImportCustomerAsync(_adapter.Adapt(eachUseCaseInput));
                }
                return true;
            }

            return false;
        }
        else
        {
            _notificationPublisher.AddNotification(new NotificationItem("Os clientes já possuem importação!"));

            var customerServiceListInput = new List<ImportCustomerServiceInput>();
            foreach (var uniqueUseCaseInput in useCaseInput)
            {
                customerServiceListInput.Add(_adapter.Adapt(uniqueUseCaseInput));
            }

            await _customerService.VerifyListCustomerIsValid(customerServiceListInput);
            return false;
        }
    }
}
