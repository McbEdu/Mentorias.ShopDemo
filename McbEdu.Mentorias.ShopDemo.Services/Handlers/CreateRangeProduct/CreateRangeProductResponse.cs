using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeProduct;

public class CreateRangeProductResponse : ResponseBase
{
    public CreateRangeProductResponse(HttpResponse httpResponse, DateTime requestedOn, string responseMessage) : base(httpResponse, requestedOn, responseMessage)
    {
    }
}
