using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderHandler : HandlerBase<CreateOrderResponse, CreateOrderRequest>
{
    public override Task<CreateOrderResponse> Handle(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }
}
