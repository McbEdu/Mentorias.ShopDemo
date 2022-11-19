using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;

public class NotifiablePublisherStandard : INotificationPublisher
{
    private NotifiableBase Notifiable { get; }

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
