using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

public interface ICustomerService
{
    Task<(bool HasExecuted, List<NotificationItem> Notifications)> ImportCustomerAsync(ImportCustomerServiceInput input);
    Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Customer> Customers)> GetCustomerAsync(GetCustomerServiceInput input);
}
