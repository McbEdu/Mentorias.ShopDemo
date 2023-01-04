namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

public class GetCustomerServiceFilteredByNameOrSurnameInput
{
    public GetCustomerServiceFilteredByNameOrSurnameInput(int page, int offset, string name, string surname)
    {
        Page = page;
        Offset = offset;
        Name = name;
        Surname = surname;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
