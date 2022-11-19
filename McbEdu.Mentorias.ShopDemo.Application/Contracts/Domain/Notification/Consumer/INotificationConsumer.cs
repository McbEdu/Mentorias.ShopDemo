using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Consumer;

public interface INotificationConsumer
{
    public NotifiableBase GetNotifiable();
}
