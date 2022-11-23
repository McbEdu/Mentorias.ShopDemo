using FluentValidation;
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
    private readonly AbstractValidator<OrderBase> _orderValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly IExtendsRepository<Customer> _customerExtendsRepository;
    private readonly IExtendsRepository<Product> _productExtendsRepository;
    private readonly AbstractValidator<CustomerBase> _customerValidator;
    private readonly AbstractValidator<ProductBase> _productValidator;
    private readonly IAdapter<CustomerStandard, CreateCustomerInputModel> _adapterCustomer;
    private readonly IAdapter<Customer, CustomerStandard> _adapterCustomerDto;
    private readonly IAdapter<ProductStandard, CreateProductInputModel> _adapterProduct;
    private readonly IAdapter<Product, ProductStandard> _adapterProductDto;
    private readonly IAdapter<Order, OrderStandard> _adapterOrderDto;

    public CreateOrderHandler(
        IExtendsRepository<Order> orderExtendsRepository,
        IAdapter<OrderStandard, CreateOrderInputModel> adapterOrder,
        INotificationPublisher notifiablePublisherStandard,
        AbstractValidator<OrderBase> orderValidator,
        IAdapter<List<NotificationItemBase>, List<ValidationFailure>> adapterNotifications,
        IExtendsRepository<Customer> customerExtendsRepository,
        AbstractValidator<CustomerBase> customerValidator,
        AbstractValidator<ProductBase> productValidator,
        IAdapter<CustomerStandard, CreateCustomerInputModel> adapterCustomer,
        IAdapter<Customer, CustomerStandard> adapterCustomerDto,
        IExtendsRepository<Product> productExtendsRepository,
        IAdapter<ProductStandard, CreateProductInputModel> adapterProduct,
        IAdapter<Product, ProductStandard> adapterProductDto,
        IAdapter<Order, OrderStandard> adapterOrderDto
        )
    {
        _orderExtendsRepository = orderExtendsRepository;
        _adapterOrder = adapterOrder;
        _notifiablePublisherStandard = notifiablePublisherStandard;
        _orderValidator = orderValidator;
        _adapterNotifications = adapterNotifications;
        _customerExtendsRepository = customerExtendsRepository;
        _customerValidator = customerValidator;
        _adapterCustomer = adapterCustomer;
        _adapterCustomerDto = adapterCustomerDto;
        _productExtendsRepository = productExtendsRepository;
        _adapterProduct = adapterProduct;
        _adapterProductDto = adapterProductDto;
        _productValidator = productValidator;
        _adapterOrderDto = adapterOrderDto;
    }

    public override async Task<CreateOrderResponse> Handle(CreateOrderRequest request)
    {
        var orderStandard = _adapterOrder.Adapt(request.Order);

        if (await _orderExtendsRepository.VerifyEntityExistsAsync(orderStandard.Code) == true)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "Esse pedido já consta no banco de dados."));
            return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "Pedido presente no banco de dados.");
        }

        var validation = _orderValidator.Validate(orderStandard);

        if (validation.IsValid == false)
        {
            _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(validation.Errors));
            return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "Pedido inválido.");
        }

        if (await _customerExtendsRepository.VerifyEntityExistsAsync(orderStandard.Customer.Email) == true)
        {
            var customer = await _customerExtendsRepository.GetAsync(orderStandard.Customer.Email);

            if (customer!.Name != request.Order.Customer.Name ||
                customer!.Surname != request.Order.Customer.Surname ||
                customer!.Birthday != request.Order.Customer.Birthday ||
                customer!.Email != request.Order.Customer.Email
                )
            {
                _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "Dados do cliente já existem, no entanto, com dados diferentes. A requisição foi realizada normalmente."));
            }
        }
        else
        {
            var adaptedCustomer = _adapterCustomer.Adapt(request.Order.Customer);
            var validationCustomer = _customerValidator.Validate(adaptedCustomer);

            if (validationCustomer.IsValid == false)
            {
                _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(validationCustomer.Errors));
                return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "Pedido inválido.");
            }

            await _customerExtendsRepository.AddAsync(_adapterCustomerDto.Adapt(adaptedCustomer));
        }

        foreach (var item in request.Order.Items)
        {
            if (await _productExtendsRepository.VerifyEntityExistsAsync(item.Product.Code) == true)
            {
                var product = await _productExtendsRepository.GetAsync(item.Product.Code);

                if (product!.Description != item.Product.Description ||
                    product!.Code != item.Product.Code)
                {
                    _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "Dados do produto já existem, no entanto, com dados diferentes. A requisição foi realizada normalmente."));
                }
            }
            else
            {
                var adaptedProduct = _adapterProduct.Adapt(item.Product);
                var validationProduct = _productValidator.Validate(adaptedProduct);

                if (validationProduct.IsValid == false)
                {
                    validationProduct.Errors.Add(new ValidationFailure("Pedido",$"O produto de código {item.Product.Code} é inválido para ser adicionado no banco de dados."));
                    _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(validationProduct.Errors));
                    return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "Pedido inválido.");
                }

                await _productExtendsRepository.AddAsync(_adapterProductDto.Adapt(adaptedProduct));
            }
        }

        var order = _adapterOrderDto.Adapt(orderStandard);
        await _orderExtendsRepository.AddAsync(order);

        return new CreateOrderResponse(new HttpResponse(TypeHttpStatusCodeResponse.Ok), request.RequestedOn, "Pedido realizado com sucesso.");
    }
}
