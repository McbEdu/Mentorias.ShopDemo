using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;

public class NotifiablePublisherStandard
{
    private NotifiableBase Notifiable { get; init; }

    public NotifiablePublisherStandard(NotifiableBase notifiable)
    {
        Notifiable = notifiable;
    }

    public void AddNotification(NotificationItemBase notificationItemBase)
    {
        Notifiable.AddNotification(notificationItemBase);
    }

    public void AddNotifications(List<NotificationItemBase> notificationItemBase)
    {
        Notifiable.AddNotifications(notificationItemBase);
    }
}
