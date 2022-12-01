namespace McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

public class ImportProductServiceInput
{
    public string Code { get; init; }
    public string Description { get; init; }

    public ImportProductServiceInput(string code, string description)
    {
        Code = code;
        Description = description;
    }
}
