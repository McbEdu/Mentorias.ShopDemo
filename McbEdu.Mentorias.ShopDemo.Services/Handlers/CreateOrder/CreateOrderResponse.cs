using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderResponse : ResponseBase
{
    public CreateOrderResponse(HttpResponse httpResponse, DateTime requestedOn, string responseMessage) : base(httpResponse, requestedOn, responseMessage)
    {
    }
}
