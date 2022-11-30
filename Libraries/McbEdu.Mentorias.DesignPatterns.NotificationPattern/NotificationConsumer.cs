using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern;

public class NotificationConsumer : INotificationConsumer<NotificationItem>
{
    private NotifiableContainerBase<NotificationItem> _notifiableContainer;

    public NotificationConsumer(NotifiableContainerBase<NotificationItem> notifiableContainer)
    {
        _notifiableContainer = notifiableContainer;
    }

    public List<NotificationItem> GetNotificationItems()
    {
        return _notifiableContainer.GetNotificationItems();
    }
}
