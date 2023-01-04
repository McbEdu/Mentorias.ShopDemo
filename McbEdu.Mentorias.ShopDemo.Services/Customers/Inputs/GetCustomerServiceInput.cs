namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

public class GetCustomerServiceInput
{
    public GetCustomerServiceInput(int page, int offset)
    {
        Page = page;
        Offset = offset;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
}