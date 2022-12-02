namespace McbEdu.Mentorias.ShopDemo.Domain.Entities;

public class OrderStandard
{
    public Guid Identifier { get; private set; }
    public string Code { get; private set; }
    public DateTime OrderTime { get; private set; }
    public List<ItemStandard> Items { get; private set; }
    public CustomerStandard Customer { get; private set; }

    public OrderStandard(Guid identifier, string code, DateTime orderTime, List<ItemStandard> items, CustomerStandard customer)
    {
        Identifier = identifier;
        Code = code;
        OrderTime = orderTime;
        Items = items;
        Customer = customer;
    }
}
