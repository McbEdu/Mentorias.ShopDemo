using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Adapters;

public class AdapterCreateItemInputModelToItemStandard : IAdapter<ItemStandard, CreateItemInputModel>
{
    private readonly IAdapter<ProductStandard, CreateProductInputModel> _adapterProduct;

    public AdapterCreateItemInputModelToItemStandard(IAdapter<ProductStandard, CreateProductInputModel> adapterProduct)
    {
        _adapterProduct = adapterProduct;
    }

    public ItemStandard Adapt(CreateItemInputModel adapter)
    {
        return new ItemStandard(adapter.Sequence, _adapterProduct.Adapt(adapter.Product), adapter.Description, adapter.Quantity, adapter.UnitaryValue);
    }
}
