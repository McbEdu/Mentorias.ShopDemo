using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetAllCustomer.Inputs;

public class GetAllCustomerUseCaseInput
{
    public GetAllCustomerUseCaseInput(int page, int offset)
    {
        Page = page;
        Offset = offset;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
}
