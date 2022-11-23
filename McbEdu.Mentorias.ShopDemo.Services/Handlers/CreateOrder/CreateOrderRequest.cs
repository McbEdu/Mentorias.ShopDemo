using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderRequest : RequestBase
{
    public CreateOrderInputModel Order { get; }

    public CreateOrderRequest(DateTime requestedOn, TypeVerbRequest typeVerbRequest, CreateOrderInputModel order) : base(requestedOn, typeVerbRequest)
    {
        Order = order;
    }
}
