using McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.UseCases.ImportOrder.Inputs;

public class ImportOrderUseCaseInput
{
    public string Code { get; init; }

    private DateTime orderTime;

    public DateTime OrderTime
    {
        get { return orderTime; }
        set { orderTime = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
    }

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
