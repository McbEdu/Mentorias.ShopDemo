using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeCustomer;

public class CreateRangeCustomerRequest : RequestBase
{
    public List<CreateCustomerInputModel> CreateRangeCustomer { get; }

    public CreateRangeCustomerRequest(DateTime requestedOn, TypeVerbRequest typeVerbRequest, List<CreateCustomerInputModel> createRangeCustomer) : base(requestedOn, typeVerbRequest)
    {
        CreateRangeCustomer = createRangeCustomer;
    }
}
