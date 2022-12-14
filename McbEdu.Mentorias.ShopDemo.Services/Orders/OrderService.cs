using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IExtendsOrderRepository _orderRepository;
    private readonly IExtendsCustomerRepository _customerRepository;
    private readonly IExtendsProductRepository _productRepository;
    private readonly IAdapter<ImportOrderServiceInput, OrderBase> _adapterOrderStandard;
    private readonly IAdapter<OrderBase, Order> _adapterOrderDataTransfer;
    private readonly AbstractValidator<OrderBase> _orderValidator;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;

    public OrderService(
        IExtendsOrderRepository orderRepository,
        IAdapter<ImportOrderServiceInput, OrderBase> adapterOrderStandard,
        IAdapter<OrderBase, Order> adapterOrderDataTransfer,
        AbstractValidator<OrderBase> orderValidator,
        INotificationPublisher<NotificationItem> notificationPublisher,
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications,
        IExtendsCustomerRepository customerRepository,
        IExtendsProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _adapterOrderStandard = adapterOrderStandard;
        _adapterOrderDataTransfer = adapterOrderDataTransfer;
        _orderValidator = orderValidator;
        _notificationPublisher = notificationPublisher;
        _adapterNotifications = adapterNotifications;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public async Task<bool> ImportOrderAsync(ImportOrderServiceInput input)
    {
        var orderStandard = _adapterOrderStandard.Adapt(input);

        var validationResult = _orderValidator.Validate(orderStandard);

        // Realiza validações
        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return false;
        }

        // Verifica se pedido já existe
        if (await _orderRepository.VerifyOrderIsRegisteredByCode(input.Code))
        {
            _notificationPublisher.AddNotification(new NotificationItem("O pedido já foi importado!"));
            return false;
        }

        // Converte para um data transfer object
        var dataTransferAdaptedOrder = _adapterOrderDataTransfer.Adapt(_adapterOrderStandard.Adapt(input));
        dataTransferAdaptedOrder.Items = dataTransferAdaptedOrder.Items
            .GroupBy(i => i.ProductCode)
            .Select(p => new Item()
            {
                Identifier = p.First().Identifier,
                Sequence = p.First().Sequence,
                UnitaryValue = p.Average(ip => ip.UnitaryValue),
                Description = string.Concat(p.Select(p => p.Description + " ")),
                ProductIdentifier = p.First().ProductIdentifier,
                ProductCode = p.First().ProductCode,
                ProductDescription = p.First().ProductDescription,
                Quantity = p.Sum(ip => ip.Quantity)
            }).ToList();

        for (int i = 0; i < dataTransferAdaptedOrder.Items.Count; i++)
        {
            dataTransferAdaptedOrder.Items[i].Sequence = i + 1;
        }

        /* Verificar se o cliente já existe
         * E, caso o cliente associado ao produto não exista, o cliente deve ser cadastrado
         * E, caso o cliente associado ao pedido exista, mas com dados diferentes, a importação deve ser feita, 
         * porém, um aviso de que o cliente existe com outros dados deve ser retornado
         */
        if (await _customerRepository.VerifyEntityExistsAsync(input.Customer.Email) == true)
        {
            var customerInDatabase = await _customerRepository.GetByEmail(input.Customer.Email);

            if (customerInDatabase.Name != input.Customer.Name ||
                customerInDatabase.Surname != input.Customer.Surname ||
                customerInDatabase.BirthDate != input.Customer.BirthDate)
            {
                _notificationPublisher.AddNotification(new NotificationItem("O cliente já está presente no banco de dados, no entanto, com credenciais incorretas."));
            }
        }
        else
        {
            await _customerRepository.AddAsync(new Customer()
            {
                Identifier = Guid.NewGuid(),
                Name = input.Customer.Name,
                Surname = input.Customer.Surname,
                BirthDate = input.Customer.BirthDate,
                Email = input.Customer.Email
            });
        }

        /*
         * E, caso os produtos associado ao pedido existam, mas com dados diferentes, a
         * importação deve ser feita, porém, um aviso de que o produto existe com outros 
         * dados deve ser retornado.
         */
        bool hasInDatabaseOne = false;
        for (int i = 0; i < dataTransferAdaptedOrder.Items.Count; i++)
        {
            Product? product = await _productRepository.GetByCode(dataTransferAdaptedOrder.Items[i].ProductCode);

            if (product is not null && product.Description != dataTransferAdaptedOrder.Items[i].ProductDescription && hasInDatabaseOne == false)
            {
                _notificationPublisher.AddNotification(new NotificationItem("Alguns produtos já existem no banco de dados, no entanto, com dados diferentes."));
                hasInDatabaseOne = true;
            }
            else
            {
                await _productRepository.AddAsync(new Product()
                {
                    Identifier = Guid.NewGuid(),
                    Description = dataTransferAdaptedOrder.Items[i].ProductDescription,
                    Code = dataTransferAdaptedOrder.Items[i].ProductCode
                });
            }
        }

        await _orderRepository.AddAsync(dataTransferAdaptedOrder);

        return true;
    }
}
