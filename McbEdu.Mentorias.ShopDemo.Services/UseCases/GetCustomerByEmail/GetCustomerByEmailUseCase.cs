using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByEmail.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByEmail;

public sealed class GetCustomerByEmailUseCase : IGetUseCase<GetCustomerByEmailUseCaseInput, List<Customer>>
{
    private readonly ICustomerService _customerService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public GetCustomerByEmailUseCase(ICustomerService customerService, INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<(bool HasDone, List<Customer> Output)> GetExecutionAsync(GetCustomerByEmailUseCaseInput input)
    {
        var response = await _customerService.GetCustomerFilteredByEmailAsync(new GetCustomerServiceFilteredByEmailInput(input.Page, input.Offset, input.Email));

        if (response.HasExecuted == false)
        {
            _notificationPublisher.AddNotifications(response.Notifications);
            return (false, response.Customers);
        }
        else
        {
            return (true, response.Customers);
        }
    }
}
