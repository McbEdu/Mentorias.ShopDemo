using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

public class CreateOrderInputModel
{
    public string Code { get; set; }
    public DateTime RequestedOn { get; set; }
    public CreateCustomerInputModel Customer { get; set; }
    public List<CreateItemInputModel> Items { get; set; }

    public CreateOrderInputModel()
    {
        Customer = new CreateCustomerInputModel();
        Items = new List<CreateItemInputModel>();
        Code = string.Empty;
    }
}