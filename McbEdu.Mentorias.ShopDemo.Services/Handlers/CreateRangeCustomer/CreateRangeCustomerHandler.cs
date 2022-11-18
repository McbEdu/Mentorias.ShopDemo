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

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeCustomer;

public class CreateRangeCustomerHandler : HandlerBase<CreateRangeCustomerResponse, CreateRangeCustomerRequest>
{
    private readonly IExtendsRepository<Customer> _customerExtendsRepository;
    private readonly AbstractValidator<CustomerBase> _customerValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<CustomerStandard, CreateCustomerInputModel> _adapterCustomer;
    private readonly IAdapter<Customer, CustomerStandard> _adapterCustomerDataTransfer;
    private readonly NotifiablePublisherStandard _notifiablePublisherStandard;

    public CreateRangeCustomerHandler(IExtendsRepository<Customer> customerExtendsRepository, AbstractValidator<CustomerBase> customerValidator,
        IAdapter<CustomerStandard, CreateCustomerInputModel> adapter, NotifiablePublisherStandard notifiablePublisherStandard,
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
        var customersStandardList = new List<CustomerStandard>();

        if (request.CreateRangeCustomer.Count < 1) 
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Lista de Clientes", "É necessário enviar uma lista de clientes válida!"));
            return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário exibir uma lista de clientes!");
        }
        
        foreach (var customerInput in request.CreateRangeCustomer)
        {
            var adaptee = _adapterCustomer.Adapt(customerInput);
            var validation = _customerValidator.Validate(adaptee);
            
            if (validation.IsValid == false)
            {
                _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(validation.Errors));
                return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário exibir uma lista de clientes!");
            }

            customersStandardList.Add(adaptee);
        }

        var customersDtoList = new List<Customer>();
        foreach (var customerStandard in customersStandardList)
        {
            var customerDtoAdaptee = _adapterCustomerDataTransfer.Adapt(customerStandard);
            customersDtoList.Add(customerDtoAdaptee);
        }

        await _customerExtendsRepository.AddRangeAsync(customersDtoList);

        return new CreateRangeCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.Created), request.RequestedOn, "O lote de clientes foi cadastrado com sucesso!");
    }
}
