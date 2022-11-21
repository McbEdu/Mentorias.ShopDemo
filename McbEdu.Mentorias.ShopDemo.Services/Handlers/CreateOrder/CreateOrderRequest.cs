using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderRequest : RequestBase
{
    public CreateOrderRequest(DateTime requestedOn, TypeVerbRequest typeVerbRequest) : base(requestedOn, typeVerbRequest)
    {
    }
}
