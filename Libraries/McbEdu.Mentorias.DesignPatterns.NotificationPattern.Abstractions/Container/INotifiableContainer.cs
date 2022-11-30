using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Item;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;

public interface INotifiableContainer<NotificationItemAbstraction> : INotificationConsumer<NotificationItemAbstraction>, INotificationPublisher<NotificationItemAbstraction>
    where NotificationItemAbstraction : INotificationItem
{

}
