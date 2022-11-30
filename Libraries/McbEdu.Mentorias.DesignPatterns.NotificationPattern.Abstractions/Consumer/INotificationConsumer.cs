using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Item;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;

public interface INotificationConsumer<NotificationItemAbstraction>
    where NotificationItemAbstraction : INotificationItem
{
    public List<NotificationItemAbstraction> GetNotificationItems();
}
