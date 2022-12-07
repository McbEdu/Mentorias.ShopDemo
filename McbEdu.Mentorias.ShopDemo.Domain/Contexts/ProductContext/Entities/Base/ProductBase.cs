using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;

public abstract class ProductBase
{
    public Guid Identifier { get; init; }
    public Code Code { get; private set; }
    public string Description { get; private set; }
    public TypeProduct TypeProduct { get; init; }

    protected ProductBase(Guid identifier, Code code, string description, TypeProduct typeProduct)
    {
        Identifier = identifier;
        Code = code;
        Description = description;
        TypeProduct = typeProduct;
    }

    protected void ChangeCode(Code code)
    {
        Code = code;
    }

    protected void ChangeDescription(string description)
    {
        Description = description;
    }

    public override bool Equals(object? obj)
    {
        var compareTo = obj as ProductBase;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Identifier.Equals(compareTo.Identifier);
    }

    public static bool operator ==(ProductBase customerBase, ProductBase customerBaseComparer)
    {
        if (ReferenceEquals(customerBase, null) || ReferenceEquals(customerBaseComparer, null)) return false;

        if (ReferenceEquals(customerBase, null) && ReferenceEquals(customerBaseComparer, null)) return true;

        return true;
    }

    public static bool operator !=(ProductBase customerBase, ProductBase customerBaseComparer)
    {
        return !(customerBase == customerBaseComparer);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
