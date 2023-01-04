using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
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

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Customer> Customers)> GetCustomerNoFilterAsync(GetCustomerServiceInput input)
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
        customers = await _customerRepository.GetCustomerByPaginationOrderringByNameAndSurnameAsync(indexCalculation, input.Offset);

        return (true, notifications, customers);
    }

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Customer> Customers)> GetCustomerFilteredByEmailAsync(GetCustomerServiceFilteredByEmailInput input)
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
        customers = await _customerRepository.GetCustomerByPaginationFilteredByEmail(input.Email, indexCalculation, input.Offset);

        return (true, notifications, customers);
    }

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Customer> Customers)> GetCustomerFilteredByNameOrSurnameAsync(GetCustomerServiceFilteredByNameOrSurnameInput input)
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
        customers = await _customerRepository.GetCustomerByPaginationFilteredByNameOrSurname(input.Name, input.Surname, indexCalculation, input.Offset);

        return (true, notifications, customers);
    }

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Customer> Customers)> GetCustomerFilteredByRangeBirthDateAsync(GetCustomerServiceFilteredByRangeBirthDateInput input)
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

        if (input.StartIn > input.FinishIn)
        {
            notifications.Add(new NotificationItem("O range final da data não pode ser menor que inicial."));
            return (false, notifications, customers);
        }

        if (input.StartIn > DateTime.UtcNow || input.FinishIn > DateTime.UtcNow)
        {
            notifications.Add(new NotificationItem("O range da data não pode ser maior que o horário atual."));
            return (false, notifications, customers);
        }

        var indexCalculation = (input.Page - 1) * input.Offset;
        customers = await _customerRepository.GetCustomerByPaginationFilteredByRangeBirthDate(input.StartIn, input.FinishIn, indexCalculation, input.Offset);

        return (true, notifications, customers);
    }
}
