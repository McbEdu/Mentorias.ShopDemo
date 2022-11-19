using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public sealed class AdapterListCreateCustomerInputModelToListCustomerStandard : IAdapter<List<CustomerStandard>, List<CreateCustomerInputModel>>
{
    private readonly IAdapter<CustomerStandard, CreateCustomerInputModel> _uniqueValueAdapter;

    public AdapterListCreateCustomerInputModelToListCustomerStandard(IAdapter<CustomerStandard, CreateCustomerInputModel> uniqueValueAdapter)
    {
        _uniqueValueAdapter = uniqueValueAdapter;
    }

    public List<CustomerStandard> Adapt(List<CreateCustomerInputModel> adapter)
    {
        var customerStandardList = new List<CustomerStandard>();

        foreach (var adaptant in adapter)
        {
            customerStandardList.Add(_uniqueValueAdapter.Adapt(adaptant));
        }

        return customerStandardList;
    }
}
