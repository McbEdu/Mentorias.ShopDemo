namespace McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;

public class Item
{
    public int Sequence { get; set; }
    public Product Product { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitaryValue { get; set; }

    public Item()
    {
        Description = string.Empty; 
        Product = new Product();
    }
}
