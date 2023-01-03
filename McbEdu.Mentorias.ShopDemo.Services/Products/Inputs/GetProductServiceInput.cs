namespace McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

public class GetProductServiceInput
{
    public GetProductServiceInput(int page, int offset, TypeGetProductService type)
    {
        Page = page;
        Offset = offset;
        Type = type;
    }

    public int Page { get; set; }
    public int Offset { get; set; }
    public TypeGetProductService Type { get; set; }
}

public enum TypeGetProductService
{
    NoFilter = 1,
    FilteredByCode = 2,
    FilteredByDescription = 3
}