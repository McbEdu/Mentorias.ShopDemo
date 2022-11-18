using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct;

public class CreateProductResponse : ResponseBase
{
    public CreateProductResponse(HttpResponse httpResponse, DateTime requestedOn, string responseMessage) : base(httpResponse, requestedOn, responseMessage)
    {
    }
}
