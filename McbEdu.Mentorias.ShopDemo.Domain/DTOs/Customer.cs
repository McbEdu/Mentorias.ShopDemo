namespace McbEdu.Mentorias.ShopDemo.Domain.DTOs;

public class Customer
{
    public Guid Identifier { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }

    public Customer()
    {
        Name = Email = Surname = string.Empty;
    }
}
