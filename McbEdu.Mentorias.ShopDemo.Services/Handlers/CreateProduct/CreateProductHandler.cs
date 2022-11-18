using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct;

public class CreateProductHandler : HandlerBase<CreateProductResponse, CreateProductRequest>
{
    public CreateProductHandler()
    {

    }

    public override Task<CreateProductResponse> Handle(CreateProductRequest request)
    {
        throw new NotImplementedException();
    }
}
