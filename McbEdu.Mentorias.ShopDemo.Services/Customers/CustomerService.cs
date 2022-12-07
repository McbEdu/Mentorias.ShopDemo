using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Services.Customers;

public class CustomerService : ICustomerService
{
    private readonly IExtendsCustomerRepository _customerRepository;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<ImportCustomerServiceInput, CustomerStandard> _adapter;
    private readonly AbstractValidator<CustomerStandard> _customerValidator;
    private readonly AbstractValidator<List<CustomerStandard>> _customerRangeValidator;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<CustomerStandard, Customer> _adapterDataTransfer;

    public CustomerService(IExtendsCustomerRepository customerRepository, INotificationPublisher<NotificationItem> notificationPublisher,
        IAdapter<ImportCustomerServiceInput, CustomerStandard> adapter, AbstractValidator<CustomerStandard> customerValidator,
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications, IAdapter<CustomerStandard, Customer> adapterDataTransfer,
        AbstractValidator<List<CustomerStandard>> customerRangeValidator)
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

        await _customerRepository.AddAsync(_adapterDataTransfer.Adapt(customerStandard));
        
        return true;
    }

    public Task<bool> VerifyCustomerIsRegistered(ImportCustomerServiceInput input)
    {
        return _customerRepository.VerifyEntityExistsAsync(input.Email);
    }

    public Task<bool> VerifyCustomerIsValid(ImportCustomerServiceInput input)
    {
        var customerStandard = _adapter.Adapt(input);

        var validationResult = _customerValidator.Validate(customerStandard);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    public Task<bool> VerifyListCustomerIsValid(List<ImportCustomerServiceInput> input)
    {
        var customerStandardList = new List<CustomerStandard>();

        foreach (var uniqueCustomerStandard in input)
        {
            customerStandardList.Add(_adapter.Adapt(uniqueCustomerStandard));
        }

        var validationResult = _customerRangeValidator.Validate(customerStandardList);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}
