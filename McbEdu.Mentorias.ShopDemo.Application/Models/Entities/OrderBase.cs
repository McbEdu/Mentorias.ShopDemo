using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

public abstract class OrderBase
{
    public Guid Identifier { get; init; }
    public string Code { get; private set; }
    public DateTime RequestedOn { get; init; }
    public CustomerBase Customer { get; private set; }
    public List<ItemBase> Items { get; private set; }
    public TypeOrder TypeOrder { get; init; }

    protected OrderBase(Guid identifier, string code, DateTime requestedOn, CustomerBase customer, List<ItemBase> items, TypeOrder typeOrder)
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
}
