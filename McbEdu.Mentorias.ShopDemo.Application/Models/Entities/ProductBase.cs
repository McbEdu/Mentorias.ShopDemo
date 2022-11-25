using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public abstract class ProductBase
{
    public Guid Identifier { get; set; }
    public string Code { get; private set; }
    public string Description { get; private set; }
    public TypeProduct TypeProduct { get; }

    protected ProductBase(Guid identifier, string code, string description, TypeProduct typeProduct)
    {
        Identifier = identifier;
        Code = code;
        Description = description;
        TypeProduct = typeProduct;
    }

    public void ChangeCode(string code)
    {
        Code = code;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }
}
