namespace McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;

public class Order
{
    public Guid Identifier { get; set; }
    public string Code { get; set; }
    public DateTime RequestedOn { get; set; }
    public Customer Customer { get; set; }
    public List<Item> Items { get; set; }

    public Order()
    {
        Items = new List<Item>();
        Customer = new Customer();
        Code = string.Empty;
    }
}
