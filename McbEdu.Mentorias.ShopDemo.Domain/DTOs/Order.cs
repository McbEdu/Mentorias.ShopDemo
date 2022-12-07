using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Domain.DTOs;

public class Order
{
    public Guid Identifier { get; set; }
    public string Code { get; set; }
    public DateTime OrderTime { get; set; }
    public Customer Customer { get; set; }
    public List<Item> Items { get; set; }

    public Order()
    {
        Code = string.Empty;
        Customer = new Customer();
        Items = new List<Item>();
    }
}
