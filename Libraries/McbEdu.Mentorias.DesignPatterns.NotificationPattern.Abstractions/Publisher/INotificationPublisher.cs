using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Item;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;

public interface INotificationPublisher<NotificationItemAbstraction>
    where NotificationItemAbstraction : INotificationItem
{
    public void AddNotification(NotificationItemAbstraction item);
    public void AddNotifications(List<NotificationItemAbstraction> items);
}
