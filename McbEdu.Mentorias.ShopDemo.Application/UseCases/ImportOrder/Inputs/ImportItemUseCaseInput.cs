using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;

public class ImportItemUseCaseInput
{
    public int Sequence { get; init; }
    public string Description { get; init; }
    public int Quantity { get; init; }
    public decimal UnitaryValue { get; init; }
    public ImportProductUseCaseInput Product { get; init; }

    public ImportItemUseCaseInput(int sequence, string description, int quantity, decimal unitaryValue, ImportProductUseCaseInput product)
    {
        Sequence = sequence;
        Description = description;
        Quantity = quantity;
        UnitaryValue = unitaryValue;
        Product = product;
    }
}
