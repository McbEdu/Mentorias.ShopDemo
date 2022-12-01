using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

public class ImportOrderServiceInput
{
    public string Code { get; init; }
    public DateTime OrderTime { get; init; }
    public ImportCustomerServiceInput Customer { get; init; }
    public List<ImportItemServiceInput> Items { get; init; }

    public ImportOrderServiceInput(string code, DateTime orderTime, ImportCustomerServiceInput customer, List<ImportItemServiceInput> items)
    {
        Code = code;
        OrderTime = orderTime;
        Customer = customer; 
        Items = items;
    }
}
