using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;
using System.ComponentModel.DataAnnotations;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

public class CreateOrderInputModel
{
    [Required]
    public string Code { get; set; }
    [Required]
    public DateTime RequestedOn { get; set; }
    [Required]
    public CreateCustomerInputModel Customer { get; set; }
    [Required]
    public List<CreateItemInputModel> Items { get; set; }

    public CreateOrderInputModel()
    {
        Customer = new CreateCustomerInputModel();
        Items = new List<CreateItemInputModel>();
        Code = string.Empty;
    }
}