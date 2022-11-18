using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeCustomer;

public class CreateRangeCustomerResponse : ResponseBase
{
    public CreateRangeCustomerResponse(HttpResponse httpResponse, DateTime requestedOn, string responseMessage) : base(httpResponse, requestedOn, responseMessage)
    {
    }
}
