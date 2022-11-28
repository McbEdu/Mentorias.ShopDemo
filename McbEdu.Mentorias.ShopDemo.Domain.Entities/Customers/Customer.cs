namespace McbEdu.Mentorias.ShopDemo.Domain.Entities.Customers;

public class Customer
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }

    public Customer(string name, string surname, string email, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        BirthDate = birthDate;
    }

    private void ChangeName(string name)
    {
        Name = name;
    }

    private void ChangeSurname(string surname)
    {
        Surname = surname;
    }

    private void ChangeEmail(string email)
    {
        Email = email;
    }

    private void ChangeBirthDate(DateTime birthDate)
    {
        BirthDate = birthDate;
    }
}
