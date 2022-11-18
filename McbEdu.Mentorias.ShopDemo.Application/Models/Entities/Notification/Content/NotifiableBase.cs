using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;

public abstract class NotifiableBase
{
    public List<NotificationItemBase> Notifications { get; }

    private TypeNotification TypeNotification { get; }

    protected NotifiableBase(TypeNotification typeNotification) 
    { 
        TypeNotification = typeNotification;
        Notifications = new List<NotificationItemBase>();
    }

    public void AddNotification(NotificationItemBase notification)
    {
        Notifications.Add(notification);
    }

    public void AddNotifications(List<NotificationItemBase> notifications)
    {
        this.Notifications.AddRange(notifications);
    }
}
