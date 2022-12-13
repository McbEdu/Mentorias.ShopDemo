using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;

public class Order
{
    public Guid Identifier { get; set; }
    public string Code { get; set; }
    public DateTime OrderTime { get; set; }
    public Guid CustomerIdentifier { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime CustomerBirthdate { get; set; }
    public List<Item> Items { get; set; }

    public Order()
    {
        Code = string.Empty;
        Items = new List<Item>();
    }
}
