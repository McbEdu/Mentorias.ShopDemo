using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Validators;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Customers;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Adapters;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddSingleton<BaseMapping<Customer>, CustomerMapping>();
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($@"Data Source=Ecommerce.db", b => b.MigrationsAssembly("McbEdu.Mentorias.ShopDemo.WebApi")));

        builder.Services.AddSingleton<IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput>, AdapterImportCustomerPayloadToUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput>, AdapterImportCustomerUseCaseInputToServiceInput>();
        builder.Services.AddSingleton<IAdapter<ImportCustomerServiceInput, CustomerStandard>, AdapterImportCustomerServiceInputToCustomerStandard>();
        builder.Services.AddSingleton<IAdapter<List<NotificationItem>, List<ValidationFailure>>, AdapterValidationFailureToNotificationItem>();
        builder.Services.AddSingleton<IAdapter<CustomerStandard, Customer>, AdapterCustomerStandardToCustomer>();
        builder.Services.AddSingleton<AbstractValidator<CustomerStandard>, CustomerValidator>();
        builder.Services.AddScoped<NotifiableContainerBase<NotificationItem>, NotifiableContainer>();
        builder.Services.AddTransient<INotificationConsumer<NotificationItem>, NotificationConsumer>();
        builder.Services.AddTransient<INotificationPublisher<NotificationItem>, NotificationPublisher>();
        builder.Services.AddScoped<IExtendsCustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IUseCase<ImportCustomerUseCaseInput>, ImportCustomerUseCase>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}