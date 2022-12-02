namespace McbEdu.Mentorias.ShopDemo.Domain.DTOs;

public class Item
{
    public Guid Identifier { get; set; }
    public int Sequence { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal UnitaryValue { get; set; }
    public Product Product { get; set; }
    public Order Order { get; set; }

    public Item()
    {
        Order = new Order();
        Description = string.Empty;
        Product = new Product();
    }
}
