using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct;

public class CreateProductRequest : RequestBase
{
    public CreateProductInputModel InputModel { get; }

    public CreateProductRequest(DateTime requestedOn, TypeVerbRequest typeVerbRequest, CreateProductInputModel inputModel) : base(requestedOn, typeVerbRequest)
    {
        InputModel = inputModel;
    }
}
