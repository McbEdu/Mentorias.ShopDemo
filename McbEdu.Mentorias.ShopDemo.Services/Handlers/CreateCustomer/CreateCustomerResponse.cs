using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;

public class CreateCustomerResponse : ResponseBase
{
    public CreateCustomerResponse(HttpResponse httpResponse, DateTime requestedOn, string responseMessage)
        : base(httpResponse, requestedOn, responseMessage)
    {
    }
}
