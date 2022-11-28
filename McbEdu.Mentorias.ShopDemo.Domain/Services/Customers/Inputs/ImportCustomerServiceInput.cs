namespace McbEdu.Mentorias.ShopDemo.Domain.Services.Customers.Inputs;

public class ImportCustomerServiceInput
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    public string BirthDate { get; init; }

    public ImportCustomerServiceInput(string name, string surname, string email, string birthdate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        BirthDate = birthdate;
    }
}
