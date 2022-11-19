using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;
using System.Text.Json.Serialization;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;

public abstract class ResponseBase
{
    [JsonIgnore]
    public string ResponseMessage { get; }

    [JsonIgnore]
    public DateTime RequestedOn { get; }

    [JsonIgnore]
    public HttpResponse HttpResponse { get; }

    protected ResponseBase(HttpResponse httpResponse, DateTime requestedOn, string responseMessage)
    {
        HttpResponse = httpResponse;
        RequestedOn = requestedOn;
        ResponseMessage = responseMessage;
    }

    public NotifiableBase Notifiable { get; private set; } = new NotifiableStandard();

    public void AddNotification(INotificationConsumer notifiableConsumerStandard)
    {
        Notifiable = notifiableConsumerStandard.GetNotifiable();
    }
}
