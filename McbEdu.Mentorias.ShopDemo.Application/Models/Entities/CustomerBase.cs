using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public abstract class CustomerBase
{
    public Guid Identifier { get; set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public DateTime Birthday { get; private set; }
    public TypeCustomer TypeCustomer { get; }

    protected CustomerBase(Guid identifier, string name, string surname, string email, DateTime birthday, TypeCustomer typeCustomer)
    {
        Identifier = identifier;
        Name = name;
        Surname = surname;
        Email = email;
        Birthday = birthday;
        TypeCustomer = typeCustomer;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }

    public void ChangeSurname(string surname)
    {
        Surname = surname;
    }

    public void ChangeEmail(string email)
    {
        Email = email;
    }
}
