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
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;

public class CreateCustomerHandler : HandlerBase<CreateCustomerResponse, CreateCustomerRequest>
{
    private readonly IExtendsRepository<Customer> _customerExtendsRepository;
    private readonly AbstractValidator<CustomerBase> _customerValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<CustomerStandard, CreateCustomerInputModel> _adapterCustomer;
    private readonly IAdapter<Customer, CustomerStandard> _adapterCustomerDataTransfer;
    private readonly INotificationPublisher _notifiablePublisherStandard;

    protected CreateCustomerHandler(IExtendsRepository<Customer> customerExtendsRepository, AbstractValidator<CustomerBase> customerValidator,
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

    public virtual async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request)
    {
        var customer = _adapterCustomer.Adapt(request.InputModel);

        var validation = _customerValidator.Validate(customer);

        if (validation.IsValid == false)
        {
            var notifications = _adapterNotifications.Adapt(validation.Errors);
            _notifiablePublisherStandard.AddNotifications(notifications);
            return new CreateCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "As credenciais do cliente não são válidas.");
        }

        if (await _customerExtendsRepository.VerifyEntityExistsAsync(customer.Email) == true)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Email", "Email já existe no banco de dados"));
            return new CreateCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "As credenciais do cliente já estão presente no banco de dados.");
        }

        await _customerExtendsRepository.AddAsync(_adapterCustomerDataTransfer.Adapt(customer));

        return new CreateCustomerResponse(new HttpResponse(TypeHttpStatusCodeResponse.Created), request.RequestedOn, "O cliente foi cadastrado com sucesso!");
    }
}
