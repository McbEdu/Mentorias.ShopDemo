using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Adapters;

public class AdapterValidationFailureToNotificationItem : IAdapter<List<NotificationItem>, List<ValidationFailure>>
{
    public List<NotificationItem> Adapt(List<ValidationFailure> adapt)
    {
        var notifications = new List<NotificationItem>();

        foreach (var validationFailure in adapt)
        {
            notifications.Add(new NotificationItem(validationFailure.ErrorMessage));
        }

        return notifications;
    }

    public List<ValidationFailure> Adapt(List<NotificationItem> adapter)
    {
        throw new NotImplementedException();
    }
}
