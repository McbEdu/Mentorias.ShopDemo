using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern;

public class NotificationPublisher : INotificationPublisher<NotificationItem>
{
    private NotifiableContainerBase<NotificationItem> _notifiableContainer;

    public NotificationPublisher(NotifiableContainerBase<NotificationItem> notifiableContainer)
    {
        _notifiableContainer = notifiableContainer;
    }

    public void AddNotification(NotificationItem item)
    {
        _notifiableContainer.AddNotification(item);
    }

    public void AddNotifications(List<NotificationItem> items)
    {
        _notifiableContainer.AddNotifications(items);
    }
}
