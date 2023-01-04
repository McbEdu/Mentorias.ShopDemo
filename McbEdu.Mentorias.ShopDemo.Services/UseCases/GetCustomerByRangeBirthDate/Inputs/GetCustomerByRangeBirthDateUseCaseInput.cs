namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.GetCustomerByRangeBirthDate.Inputs;

public class GetCustomerByRangeBirthDateUseCaseInput
{
    public GetCustomerByRangeBirthDateUseCaseInput(int page, int offset, DateTime startIn, DateTime endIn)
    {
        Page = page;
        Offset = offset;
        StartIn = startIn;
        EndIn = endIn;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
    public DateTime StartIn { get; set; }
    public DateTime EndIn { get; set; }
}
