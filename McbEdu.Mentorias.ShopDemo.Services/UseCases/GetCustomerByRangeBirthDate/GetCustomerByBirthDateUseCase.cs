using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByRangeBirthDate.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByRangeBirthDate;

public class GetCustomerByBirthDateUseCase : IGetUseCase<GetCustomerByRangeBirthDateUseCaseInput, List<Customer>>
{
    private readonly ICustomerService _customerService;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;

    public GetCustomerByBirthDateUseCase(ICustomerService customerService, INotificationPublisher<NotificationItem> notificationPublisher)
    {
        _customerService = customerService;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<(bool HasDone, List<Customer> Output)> GetExecutionAsync(GetCustomerByRangeBirthDateUseCaseInput input)
    {
        var response = await _customerService.GetCustomerFilteredByRangeBirthDateAsync(
            new GetCustomerServiceFilteredByRangeBirthDateInput(input.Page, input.Offset, input.StartIn, input.EndIn));

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
