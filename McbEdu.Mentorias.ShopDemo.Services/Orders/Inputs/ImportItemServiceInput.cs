using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

public class ImportItemServiceInput
{
    public int Sequence { get; init; }
    public int Quantity { get; init; }
    public decimal UnitaryValue { get; init; }
    public string Description { get; init; }
    public ImportProductServiceInput Product { get; init; }

    public ImportItemServiceInput(int sequence, int quantity, decimal unitaryValue, string description, ImportProductServiceInput product)
    {
        Sequence = sequence;
        Quantity = quantity;
        UnitaryValue = unitaryValue;
        Description = description;
        Product = product;
    }
}
