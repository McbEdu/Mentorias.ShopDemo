using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer;

public class ImportCustomerUseCase : IUseCase<ImportCustomerUseCaseInput>
{
    private readonly ICustomerService _customerService;
    private readonly IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> _adapter;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IUnitOfWork _unitOfWork;

    public ImportCustomerUseCase(ICustomerService customerService, 
        IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput> adapter, IUnitOfWork unitOfWork,
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _adapter = adapter;
        _unitOfWork = unitOfWork;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteAsync(ImportCustomerUseCaseInput useCaseInput)
    {
        return await _unitOfWork.ExecuteAsync((async () =>
        {
            var response = await _customerService.ImportCustomerAsync(_adapter.Adapt(useCaseInput));

            if(response.Item1 == false)
            {
                _notificationPublisher.AddNotifications(response.Item2);
                return false;
            }

            return true;
        }));
    }
}
