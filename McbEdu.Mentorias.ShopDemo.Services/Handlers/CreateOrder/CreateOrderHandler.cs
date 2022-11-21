using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderHandler : HandlerBase<CreateOrderResponse, CreateOrderRequest>
{
    private readonly IExtendsRepository<Order> _orderExtendsRepository;
    private readonly IAdapter<OrderStandard, CreateOrderInputModel> _adapterOrder;

    public CreateOrderHandler(
        IExtendsRepository<Order> orderExtendsRepository,
        IAdapter<OrderStandard, CreateOrderInputModel> adapterOrder
        )
    {
        _orderExtendsRepository = orderExtendsRepository;
        _adapterOrder = adapterOrder;
    }

    public override Task<CreateOrderResponse> Handle(CreateOrderRequest request)
    {
        var orderStandard = _adapterOrder.Adapt(request.Order);

        throw new NotImplementedException();
    }
}
