namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

public class GetCustomerServiceInput
{
    public GetCustomerServiceInput(int page, int offset, TypeGetCustomerService type)
    {
        Page = page;
        Offset = offset;
        Type = type;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
    public TypeGetCustomerService Type { get; set; }
}

public enum TypeGetCustomerService
{
    NoFilter = 1,
    ByEmail = 2,
    Name = 3,
    BirthDate = 4
}
