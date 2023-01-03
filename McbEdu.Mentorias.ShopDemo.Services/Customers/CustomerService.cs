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

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications)> ImportCustomerAsync(ImportCustomerServiceInput input)
    {
        var notifications = new List<NotificationItem>();
        var customerStandard = _adapter.Adapt(input);

        var validationResult = _customerValidator.Validate(customerStandard);

        if (validationResult.IsValid == false)
        {
            notifications.AddRange(_adapterNotifications.Adapt(validationResult.Errors));
            return (false, notifications);
        }

        if (await _customerRepository.VerifyEntityExistsAsync(input.Email))
        {
            notifications.Add(new NotificationItem($"O cliente de email {input.Email} já possui cadastro."));
            return (false, notifications);
        }

        if (await _customerRepository.VerifyEntityExistsLocalAsync(input.Email))
        {
            notifications.Add(new NotificationItem($"Não é possível importar clientes com mesmo email."));
            return (false, notifications);
        }

        await _customerRepository.AddAsync(_adapterDataTransfer.Adapt(customerStandard));
        
        return (true, notifications);
    }

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Customer> Customers)> GetCustomerAsync(GetCustomerServiceInput input)
    {
        var notifications = new List<NotificationItem>();
        var customers = new List<Customer>();

        if (input.Page < 1)
        {
            notifications.Add(new NotificationItem("A página precisa ser maior ou igual que 1"));
            return (false, notifications, customers);
        }

        if (input.Offset > 30)
        {
            notifications.Add(new NotificationItem("A quantidade de clientes por paginação a ser retornada por cliente tem que ser menor que 30."));
            return (false, notifications, customers);
        }

        var indexCalculation = (input.Page - 1) * input.Offset;
        
        if (input.Type == TypeGetCustomerService.NoFilter)
        {
            customers = await _customerRepository.GetCustomerByPaginationOrderringByNameAndSurnameAsync(indexCalculation, input.Offset);
        }
        else if (input.Type == TypeGetCustomerService.ByEmail)
        {
            customers = await _customerRepository.GetCustomerByPaginationFilteredByEmail(indexCalculation, input.Offset);
        }
        else if (input.Type == TypeGetCustomerService.Name)
        {
            customers = await _customerRepository.GetCustomerByPaginationFilteredByNameOrSurname(indexCalculation, input.Offset);
        }
        else if (input.Type == TypeGetCustomerService.BirthDate)
        {
            customers = await _customerRepository.GetCustomerByPaginationFilteredByRangeBirthDate(indexCalculation, input.Offset);
        }
        else
        {
            throw new Exception("Não existe nenhum caracterizado por esse valor inteiro.");
        }

        return (true, notifications, customers);
    }
}
