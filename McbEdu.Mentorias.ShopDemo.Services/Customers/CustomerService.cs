using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers;

public class CustomerService : ICustomerService
{
    private readonly IExtendsCustomerRepository _customerRepository;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<ImportCustomerServiceInput, CustomerBase> _adapter;
    private readonly AbstractValidator<CustomerBase> _customerValidator;
    private readonly AbstractValidator<List<CustomerBase>> _customerRangeValidator;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<CustomerBase, Customer> _adapterDataTransfer;

    public CustomerService(IExtendsCustomerRepository customerRepository, INotificationPublisher<NotificationItem> notificationPublisher,
        IAdapter<ImportCustomerServiceInput, CustomerBase> adapter, AbstractValidator<CustomerBase> customerValidator,
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications, IAdapter<CustomerBase, Customer> adapterDataTransfer,
        AbstractValidator<List<CustomerBase>> customerRangeValidator)
    {
        _customerRepository = customerRepository;
        _notificationPublisher = notificationPublisher;
        _adapter = adapter;
        _customerValidator = customerValidator;
        _adapterNotifications = adapterNotifications;
        _adapterDataTransfer = adapterDataTransfer;
        _customerRangeValidator = customerRangeValidator;
    }

    public async Task<Customer> GetCustomerAsync(ImportCustomerServiceInput input)
    {
        return await _customerRepository.GetByEmail(input.Email);
    }

    public async Task<bool> ImportCustomerAsync(ImportCustomerServiceInput input)
    {
        var customerStandard = _adapter.Adapt(input);

        var validationResult = _customerValidator.Validate(customerStandard);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return false;
        }

        if (await _customerRepository.VerifyEntityExistsAsync(input.Email))
        {
            _notificationPublisher.AddNotification(new NotificationItem($"O cliente de email {input.Email} já possui cadastro."));
            return false;
        }

        await _customerRepository.AddAsync(_adapterDataTransfer.Adapt(customerStandard));
        
        return true;
    }
}
