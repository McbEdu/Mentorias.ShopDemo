using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Consumer;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Content;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Validators;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeCustomer;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IBaseMapping<Customer>, CustomerBaseMapping>();
        builder.Services.AddSingleton<IBaseMapping<Product>, ProductBaseMapping>();
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($@"Data Source=Ecommerce.db", b => b.MigrationsAssembly("McbEdu.Mentorias.ShopDemo.Infrascructure")));
        builder.Services.AddScoped<DataContext>();
        builder.Services.AddScoped<IExtendsRepository<Customer>, ExtendsCustomerRepository>();

        builder.Services.AddScoped<NotifiableBase, NotifiableStandard>();
        builder.Services.AddTransient<NotifiablePublisherStandard>();
        builder.Services.AddTransient<NotifiableConsumerStandard>();
        builder.Services.AddScoped<IAdapter<CustomerStandard, CreateCustomerInputModel>, AdapterCreateCustomerInputModelToCustomerStandard>();
        builder.Services.AddScoped<IAdapter<List<NotificationItemBase>, List<ValidationFailure>>, AdapterValidationFailureListToNotificationItemList>();
        builder.Services.AddScoped<IAdapter<Customer, CustomerStandard>, AdapterCustomerStandardToCustomerDTO>();
        builder.Services.AddScoped<AbstractValidator<CustomerBase>, CustomerValidator>();
        builder.Services.AddTransient<HandlerBase<CreateCustomerResponse, CreateCustomerRequest>, CreateCustomerHandler>();
        builder.Services.AddTransient<HandlerBase<CreateRangeCustomerResponse, CreateRangeCustomerRequest>, CreateRangeCustomerHandler>();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}