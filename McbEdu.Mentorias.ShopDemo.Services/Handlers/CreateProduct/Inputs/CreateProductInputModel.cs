namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

public class CreateProductInputModel
{
    public string Code { get; set; }
    public string Description { get; set; }

    public CreateProductInputModel()
    {
        Code = Description = string.Empty;
    }
}
