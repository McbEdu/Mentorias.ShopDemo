using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public sealed class AdapterValidationFailureListToNotificationItemList : IAdapter<List<NotificationItemBase>, List<ValidationFailure>>
{
    public List<NotificationItemBase> Adapt(List<ValidationFailure> adapter)
    {
        var notificationsItems = new List<NotificationItemBase>();
        foreach (var validationFailure in adapter)
        {
            notificationsItems.Add(new NotificationItemStandard(validationFailure.PropertyName, validationFailure.ErrorMessage));
        }
        return notificationsItems;
    }
}
