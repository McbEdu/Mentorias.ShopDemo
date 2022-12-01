namespace McbEdu.Mentorias.ShopDemo.Domain.Entities;

public class ProductStandard
{
    public Guid Identifier { get; init; }
    public string Code { get; init; }
    public string Description { get; init; }

    public ProductStandard(Guid identifier, string code, string description)
    {
        Identifier = identifier;
        Code = code;
        Description = description;
    }
}
