using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateOrder;

public class CreateOrderHandler : HandlerBase<CreateOrderResponse, CreateOrderRequest>
{
    private readonly INotificationPublisher _notifiablePublisherStandard;
    private readonly IAdapter<OrderStandard, CreateOrderInputModel> _adapterInputOrderToOrderStandard;
    private readonly AbstractValidator<OrderBase> _orderValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly IExtendsRepository<Order> _orderExtendsRepository;
    private readonly IExtendsRepository<Product> _productExtendsRepository;
    private readonly IExtendsRepository<Customer> _customerExtendsRepository;
    private readonly IAdapter<Order, OrderStandard> _adapterOrderStandardToOrder;
    private readonly AbstractValidator<CustomerBase> _customerValidator;

    public CreateOrderHandler(
        INotificationPublisher notifiablePublisherStandard,
        IAdapter<OrderStandard, CreateOrderInputModel> adapterInputOrderToOrderStandard,
        IAdapter<Order, OrderStandard> adapterOrderStandardToOrder,
        AbstractValidator<OrderBase> orderValidator,
        AbstractValidator<CustomerBase> customerValidator,
        IAdapter<List<NotificationItemBase>, List<ValidationFailure>> adapterNotifications,
        IExtendsRepository<Order> orderExtendsRepository,
        IExtendsRepository<Product> productExtendsRepository,
        IExtendsRepository<Customer> customerExtendsRepository)
    {
        _notifiablePublisherStandard = notifiablePublisherStandard;
        _adapterInputOrderToOrderStandard = adapterInputOrderToOrderStandard;
        _orderValidator = orderValidator;
        _adapterNotifications = adapterNotifications;
        _orderExtendsRepository = orderExtendsRepository;
        _productExtendsRepository = productExtendsRepository;
        _customerExtendsRepository = customerExtendsRepository;
        _adapterOrderStandardToOrder = adapterOrderStandardToOrder;
        _customerValidator = customerValidator;
    }

    public override async Task<CreateOrderResponse> Handle(CreateOrderRequest request)
    {
        // Validações
        if (request.Order == null)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "O pedido de requisição é inválido."));
            return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "O input de pedido não é valido.");
        }

        var orderStandard = _adapterInputOrderToOrderStandard.Adapt(request.Order);

        var validation = _orderValidator.Validate(orderStandard);

        if (validation.IsValid == false)
        {
            _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(validation.Errors));
            return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "O input de pedido não é valido.");
        }

        if (await _orderExtendsRepository.VerifyEntityExistsAsync(orderStandard.Code) == true)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "O pedido já existe."));
            return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "O input de pedido não é valido.");
        }

        var order = _adapterOrderStandardToOrder.Adapt(orderStandard);

        // Customer
        if (await _customerExtendsRepository.VerifyEntityExistsAsync(order.Customer.Email) == true)
        {
            Customer customerInformationIfNeedsToGetInTheDatabase = (await _customerExtendsRepository.GetAsync(orderStandard.Customer.Email))!;

            if (order.Customer.Name != customerInformationIfNeedsToGetInTheDatabase!.Name ||
                order.Customer.Surname != customerInformationIfNeedsToGetInTheDatabase!.Surname ||
                order.Customer.Birthday != customerInformationIfNeedsToGetInTheDatabase!.Birthday )
            {
                _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "O cliente já existe, no entanto com dados diferentes."));
            }

            order.Customer = customerInformationIfNeedsToGetInTheDatabase;
        }
        else
        {
            var customerValidation = _customerValidator.Validate(orderStandard.Customer);

            if (customerValidation.IsValid == false)
            {
                _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(customerValidation.Errors));
                return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "O input de pedido não é valido.");
            }
        }

        // Products Items
        foreach (var item in order.Items)
        {
            if (await _productExtendsRepository.VerifyEntityExistsAsync(item.Product.Code) == true)
            {
                Product productInformationIfNeedsToGetInTheDatabase = (await _productExtendsRepository.GetAsync(item.Product.Code))!;

                if (item.Product.Description != productInformationIfNeedsToGetInTheDatabase.Description)
                {
                    _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", $"O produto {item.Product.Code} já existe, no entanto com dados diferentes."));
                }

                item.Product = productInformationIfNeedsToGetInTheDatabase;
            }
        }

        await _orderExtendsRepository.AddAsync(order);

        return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.Ok), request.RequestedOn, "Pedido realizado com sucesso.");
    }
}
