using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Item;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Updater;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;

public interface INotifiableContainer<NotificationItemAbstraction> : 
    INotificationConsumer<NotificationItemAbstraction>, 
    INotificationPublisher<NotificationItemAbstraction>,
    INotificationUpdater
    where NotificationItemAbstraction : INotificationItem
{

}
