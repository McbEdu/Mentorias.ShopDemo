using FluentValidation.Results;
using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Domain.Notification.Publisher;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeCustomer;

public class CreateRangeCustomerHandler : HandlerBase<CreateRangeCustomerResponse, CreateRangeCustomerRequest>
{
    private readonly IExtendsRepository<Customer> _customerExtendsRepository;
    private readonly AbstractValidator<CustomerBase> _customerValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<CustomerStandard, CreateCustomerInputModel> _adapterCustomer;
    private readonly IAdapter<Customer, CustomerStandard> _adapterCustomerDataTransfer;
    private readonly INotificationPublisher _notifiablePublisherStandard;

    public CreateRangeCustomerHandler(IExtendsRepository<Customer> customerExtendsRepository, AbstractValidator<CustomerBase> customerValidator,
        IAdapter<CustomerStandard, CreateCustomerInputModel> adapter, INotificationPublisher notifiablePublisherStandard,
        IAdapter<Customer, CustomerStandard> adapterCustomerDataTransfer, IAdapter<List<NotificationItemBase>, List<ValidationFailure>> adapterNotifications)
    {
        _customerExtendsRepository = customerExtendsRepository;
        _customerValidator = customerValidator;
        _adapterCustomer = adapter;
        _notifiablePublisherStandard = notifiablePublisherStandard;
        _adapterCustomerDataTransfer = adapterCustomerDataTransfer;
        _adapterNotifications = adapterNotifications;
    }

    public async override Task<CreateRangeCustomerResponse> Handle(CreateRangeCustomerRequest request)
    {
        if (request.CreateRangeCustomer == null)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Pedido", "O pedido de requisição é inválido."));
            return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "As credenciais do cliente não são válidas.");
        }

        var customersStandardList = new List<CustomerStandard>();

        if (request.CreateRangeCustomer.Count < 1) 
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Lista de Clientes", "É necessário enviar uma lista de clientes válida!"));
            return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário exibir uma lista de clientes!");
        }

        bool allCustomerIsValid = true;
        foreach (var customerInput in request.CreateRangeCustomer)
        {
            var adaptee = _adapterCustomer.Adapt(customerInput);
            var validation = _customerValidator.Validate(adaptee);
            
            if (validation.IsValid == false)
            {
                var newValidationErrors = new List<ValidationFailure>();

                foreach (var validationFailure in validation.Errors)
                {
                    newValidationErrors.Add(new ValidationFailure(validationFailure.PropertyName, $"Cliente {adaptee.Name}. {validationFailure.ErrorMessage}"));
                }

                _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(newValidationErrors));
                allCustomerIsValid = false;
            }

            customersStandardList.Add(adaptee);
        }

        if (allCustomerIsValid == true)
        {
            return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário exibir uma lista de clientes!");
        }

        var customersDtoList = new List<Customer>();
        foreach (var customerStandard in customersStandardList)
        {
            var customerDtoAdaptee = _adapterCustomerDataTransfer.Adapt(customerStandard);
            customersDtoList.Add(customerDtoAdaptee);
        }

        var existsAnyCustomerInDatabase = false;
        foreach (var customer in customersDtoList)
        {
            if (await _customerExtendsRepository.VerifyEntityExistsAsync(customer.Email))
            {
                existsAnyCustomerInDatabase = true;
                _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Cliente", $"O cliente com email {customer.Email} já está importado."));
            }
        }

        if (existsAnyCustomerInDatabase)
        {
            return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário importar uma lista de clientes válida!");
        }

        await _customerExtendsRepository.AddRangeAsync(customersDtoList);

        return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.Created), request.RequestedOn, "O lote de clientes foi cadastrado com sucesso!");
    }
}
