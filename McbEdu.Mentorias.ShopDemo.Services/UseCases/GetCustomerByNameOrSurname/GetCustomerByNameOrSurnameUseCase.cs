using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByNameOrSurname.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByNameOrSurname;

public sealed class GetCustomerByNameOrSurnameUseCase : IGetUseCase<GetCustomerByNameOrSurnameUseCaseInput, List<Customer>>
{
    private readonly ICustomerService _customerService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public GetCustomerByNameOrSurnameUseCase(
        ICustomerService customerService, 
        INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<(bool HasDone, List<Customer> Output)> GetExecutionAsync(GetCustomerByNameOrSurnameUseCaseInput input)
    {
        var response = await _customerService.GetCustomerFilteredByNameOrSurnameAsync(new Customers.Inputs.GetCustomerServiceFilteredByNameOrSurnameInput(input.Page, input.Offset, input.Name, input.Surname));

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
