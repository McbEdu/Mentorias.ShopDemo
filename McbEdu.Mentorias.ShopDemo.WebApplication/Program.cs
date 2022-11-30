using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Interfaces;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

namespace McbEdu.Mentorias.ShopDemo.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IUseCase<ImportCustomerUseCaseInput>, ImportCustomerUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput>, AdapterImportCustomerPayloadToUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput>, AdapterImportCustomerUseCaseInputToServiceInput>();
        builder.Services.AddScoped<NotifiableContainerBase<NotificationItem>, NotifiableContainer>();
        builder.Services.AddTransient<INotificationConsumer<NotificationItem>, NotificationConsumer>();
        builder.Services.AddTransient<INotificationPublisher<NotificationItem>, NotificationPublisher>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

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