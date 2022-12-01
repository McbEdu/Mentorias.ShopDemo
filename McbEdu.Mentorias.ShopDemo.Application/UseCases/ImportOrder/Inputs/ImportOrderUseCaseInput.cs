using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;

public class ImportOrderUseCaseInput
{
    public string Code { get; init; }
    public DateTime OrderTime { get; init; }
    public ImportCustomerUseCaseInput Customer { get; init; }
    public List<ImportItemUseCaseInput> Items { get; init; }

    public ImportOrderUseCaseInput(string code, DateTime orderTime, ImportCustomerUseCaseInput customer, List<ImportItemUseCaseInput> items)
    {
        Code = code;
        OrderTime = orderTime;
        Customer = customer;
        Items = items;
    }
}
