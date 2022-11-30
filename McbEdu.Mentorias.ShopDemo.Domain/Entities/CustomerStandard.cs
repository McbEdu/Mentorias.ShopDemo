namespace McbEdu.Mentorias.ShopDemo.Domain.Entities;

public class CustomerStandard
{
    public Guid Identifier { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }

    public CustomerStandard(Guid identifier, string name, string surname, string email, DateTime birthDate)
    {
        Identifier = identifier;
        Name = name;
        Surname = surname;
        Email = email;
        BirthDate = birthDate;
    }
}