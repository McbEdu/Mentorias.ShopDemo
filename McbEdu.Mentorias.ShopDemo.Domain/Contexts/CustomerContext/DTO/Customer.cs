using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;

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
