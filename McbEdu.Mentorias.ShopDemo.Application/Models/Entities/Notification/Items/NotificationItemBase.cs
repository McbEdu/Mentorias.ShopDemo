using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using System.Text.Json.Serialization;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;

public abstract class NotificationItemBase
{
    [JsonIgnore]
    public string Title { get; }
    public string Message { get; }
    private TypeNotification TypeNotification { get; }

    protected NotificationItemBase(string title, string message, TypeNotification typeNotification)
    {
        Title = title;
        Message = message;
        TypeNotification = typeNotification;
    }
}
