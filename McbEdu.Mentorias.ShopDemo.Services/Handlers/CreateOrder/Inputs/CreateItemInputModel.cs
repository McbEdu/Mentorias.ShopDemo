using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

public class CreateItemInputModel
{
    public int Sequence { get; set; }
    public CreateProductInputModel Product { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitaryValue { get; set; }

    public CreateItemInputModel()
    {
        Description = string.Empty;
        Product = new CreateProductInputModel();
    }
}
