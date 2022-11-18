namespace McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;

public class Product
{
    public Guid Identifier { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

    public Product()
    {
        Code = Description = string.Empty;
    }
}