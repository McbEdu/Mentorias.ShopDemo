using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Updater;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern;

public class NotificationUpdater : INotificationUpdater
{
    private NotifiableContainerBase<NotificationItem> _container;

    public NotificationUpdater(NotifiableContainerBase<NotificationItem> container)
    {
        _container = container;
    }

    public void RemoveAllNotifications()
    {
        _container.RemoveAllNotifications();
    }
}
