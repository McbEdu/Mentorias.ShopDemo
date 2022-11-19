using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;

public abstract class NotificationItemBase
{
    public string Title { get; }
    public string Message { get; }
    private TypeNotification TypeNotification { get; }

    protected NotificationItemBase(string title, string message, TypeNotification typeNotification)
    {
        Title = title;
        Message = message;
        TypeNotification = typeNotification;
    }

    public TypeNotification GetNotificationType()
    {
        return TypeNotification;
    }
}
