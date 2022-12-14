using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportRangeCustomer;

public class ImportRangeCustomerUseCase : IUseCase<List<ImportCustomerUseCaseInput>>
{
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> _adapter;
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public ImportRangeCustomerUseCase(ICustomerService customerService, IAdapter<ImportCustomerUseCaseInput,
        ImportCustomerServiceInput> adapter, IUnitOfWork unitOfWork, INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _adapter = adapter;
        _unitOfWork = unitOfWork;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteAsync(List<ImportCustomerUseCaseInput> useCaseInput)
    {
        return await _unitOfWork.ExecuteAsync((async () =>
        {
            for (int i = 0; i < useCaseInput.Count; i++)
            {
                var response = await _customerService.ImportCustomerAsync(_adapter.Adapt(useCaseInput[i]));
                if (response.Item1 == false)
                {
                    var newValidationResultNotifications = new List<NotificationItem>();

                    foreach (var notificationItem in response.Item2)
                    {
                        newValidationResultNotifications.Add(new NotificationItem($"Cliente de indexador {(i + 1)}. {notificationItem.Message}"));
                    }

                    _notificationPublisher.AddNotifications(newValidationResultNotifications);
                    return false;
                }
            }

            return true;
        }));
    }
}
