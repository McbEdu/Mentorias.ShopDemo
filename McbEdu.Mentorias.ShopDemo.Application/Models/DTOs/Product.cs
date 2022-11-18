namespace McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;

public class Product
{
    public Guid Identifier { get; }
    public string Code { get; }
    public string Description { get; }

    public Product()
    {
        Code = Description = string.Empty;
    }
}