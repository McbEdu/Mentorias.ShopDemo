namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

public class ImportCustomerServiceInput
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    private DateTime birthDate;

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
    }

    public ImportCustomerServiceInput(string name, string surname, string email, DateTime birthdate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        BirthDate = birthdate;
    }
}
