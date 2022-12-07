using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;

public class Product
{
    public Guid Identifier { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }

    public Product()
    {
        Code = Description = string.Empty;
        Items = new List<Item>();
    }
}
