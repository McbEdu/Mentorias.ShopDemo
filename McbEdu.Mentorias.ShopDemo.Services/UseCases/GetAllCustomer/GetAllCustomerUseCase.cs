using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetAllCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetAllCustomer;

public sealed class GetAllCustomerUseCase : IGetUseCase<GetAllCustomerUseCaseInput, List<Customer>>
{
    private readonly ICustomerService _customerService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public GetAllCustomerUseCase(ICustomerService customerService, INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<(bool HasDone, List<Customer> Output)> GetExecutionAsync(GetAllCustomerUseCaseInput input)
    {
        var getCustomerServiceResponse = await _customerService.GetCustomerNoFilterAsync(new GetCustomerServiceInput(input.Page, input.Offset));

        if (getCustomerServiceResponse.HasExecuted == false)
        {
            _notificationPublisher.AddNotifications(getCustomerServiceResponse.Notifications);
            return (false, getCustomerServiceResponse.Customers);
        }
        else
        {
            return (true, getCustomerServiceResponse.Customers); 
        }
    }
}
