namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

public class GetCustomerServiceFilteredByEmailInput
{
    public GetCustomerServiceFilteredByEmailInput(int page, int offset, string email)
    {
        Page = page;
        Offset = offset;
        Email = email;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
    public string Email { get; set; }
}
