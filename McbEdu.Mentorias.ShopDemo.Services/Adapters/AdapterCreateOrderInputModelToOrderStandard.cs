using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterCreateOrderInputModelToOrderStandard : IAdapter<OrderStandard, CreateOrderInputModel>
{
    private readonly IAdapter<CustomerStandard, CreateCustomerInputModel> _adapterCustomer;
    private readonly IAdapter<List<ItemStandard>, List<CreateItemInputModel>> _adapterItems;

    public AdapterCreateOrderInputModelToOrderStandard(
        IAdapter<CustomerStandard, CreateCustomerInputModel> adapterCustomer,
        IAdapter<List<ItemStandard>, List<CreateItemInputModel>> adapterItems)
    {
        _adapterCustomer = adapterCustomer;
        _adapterItems = adapterItems;
    }

    public OrderStandard Adapt(CreateOrderInputModel adapter)
    {
        return new OrderStandard(Guid.NewGuid(), adapter.Code, adapter.RequestedOn, _adapterCustomer.Adapt(adapter.Customer), _adapterItems.Adapt(adapter.Items));
    }
}
