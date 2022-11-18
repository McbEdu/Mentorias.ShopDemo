using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeProduct;

public class CreateRangeProductRequest : RequestBase
{
    public List<CreateProductInputModel> InputModels { get; }

    public CreateRangeProductRequest(DateTime requestedOn, TypeVerbRequest typeVerbRequest, List<CreateProductInputModel> inputModels) : base(requestedOn, typeVerbRequest)
    {
        InputModels = inputModels;
    }
}
