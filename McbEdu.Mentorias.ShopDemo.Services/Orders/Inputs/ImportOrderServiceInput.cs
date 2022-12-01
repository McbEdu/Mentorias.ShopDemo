using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;

public class ImportOrderServiceInput
{
    public string Code { get; init; }
    public string Description { get; init; }
    public ImportCustomerServiceInput Customer { get; init; }
    public List<ImportItemServiceInput> Items { get; init; }

    public ImportOrderServiceInput(string code, string description, ImportCustomerServiceInput customer, List<ImportItemServiceInput> items)
    {
        Code = code;
        Description = description; 
        Customer = customer; 
        Items = items;
    }
}
