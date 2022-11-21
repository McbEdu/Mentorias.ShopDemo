using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderHandler : HandlerBase<CreateOrderResponse, CreateOrderRequest>
{
    private readonly IExtendsRepository<Order> _orderExtendsRepository;
    private readonly IAdapter<OrderStandard, CreateOrderInputModel> _adapterOrder;
    private readonly INotificationPublisher _notifiablePublisherStandard;

    public CreateOrderHandler(
        IExtendsRepository<Order> orderExtendsRepository,
        IAdapter<OrderStandard, CreateOrderInputModel> adapterOrder,
        INotificationPublisher notifiablePublisherStandard
        )
    {
        _orderExtendsRepository = orderExtendsRepository;
        _adapterOrder = adapterOrder;
        _notifiablePublisherStandard = notifiablePublisherStandard;
    }

    public override async Task<CreateOrderResponse> Handle(CreateOrderRequest request)
    {
        var orderStandard = _adapterOrder.Adapt(request.Order);

        if (await _orderExtendsRepository.VerifyEntityExistsAsync(orderStandard.Code) == true)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "Esse pedido já consta no banco de dados."));
            return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "Pedido presente no banco de dados.");
        }

        throw new NotImplementedException();
    }
}
