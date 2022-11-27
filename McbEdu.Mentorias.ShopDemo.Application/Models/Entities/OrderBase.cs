using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public abstract class OrderBase
{
    public Guid Identifier { get; init; }
    public string Code { get; private set; }
    public DateTime RequestedOn { get; init; }
    public CustomerStandard Customer { get; private set; }
    public List<ItemStandard> Items { get; private set; }
    public TypeOrder TypeOrder { get; init; }

    protected OrderBase(Guid identifier, string code, DateTime requestedOn, CustomerStandard customer, List<ItemStandard> items, TypeOrder typeOrder)
    {
        Identifier = identifier;
        Code = code;
        RequestedOn = requestedOn;
        Customer = customer;
        TypeOrder = typeOrder;
        Items = items;
    }

    public void ChangeCode(string code)
    {
        Code = code;
    }

    public void ChangeCustomer(CustomerStandard customer)
    {
        Customer = customer;
    }
}
