using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Item;

namespace McbEdu.Mentorias.DesignPatterns.NotificationPattern;

public class NotificationItem : INotificationItem
{
    public string Message { get; init; }

    public NotificationItem(string message)
    {
        Message = message;
    }
}
