namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByEmail.Inputs;

public class GetCustomerByEmailUseCaseInput
{
    public GetCustomerByEmailUseCaseInput(int page, int offset, string email)
    {
        Page = page;
        Offset = offset;
        Email = email;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
    public string Email { get; set; }
}
