using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;

public class NotifiableConsumerStandard : INotificationConsumer
{
    private NotifiableBase Notifiable { get; }

    public NotifiableConsumerStandard(NotifiableBase notifiable)
    {
        Notifiable = notifiable;
    }

    public NotifiableBase GetNotifiable()
    {
        return Notifiable;
    }
}
