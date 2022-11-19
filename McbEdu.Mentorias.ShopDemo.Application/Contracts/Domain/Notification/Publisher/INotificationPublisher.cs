using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Publisher;

public interface INotificationPublisher
{
    public void AddNotification(NotificationItemBase notificationItemBase);
    public void AddNotifications(List<NotificationItemBase> notificationItemBase);
}
