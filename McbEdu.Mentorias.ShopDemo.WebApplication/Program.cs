using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Container;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Abstractions;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.Adapters;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportOrder.Inputs;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportRangeCustomer;
using McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportRangeProduct;
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
using McbEdu.Mentorias.ShopDemo.Services.Items;
using McbEdu.Mentorias.ShopDemo.Services.Items.Adapters;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Items.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Orders;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Adapters;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Orders.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products;
using McbEdu.Mentorias.ShopDemo.Services.Products.Adapters;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Adapters;
using McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<BaseMapping<Order>, OrderMapping>();
        builder.Services.AddSingleton<BaseMapping<Item>, ItemMapping>();
        builder.Services.AddSingleton<BaseMapping<Customer>, CustomerMapping>();
        builder.Services.AddSingleton<BaseMapping<Product>, ProductMapping>();

        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($@"Data Source=Ecommerce.db", b => b.MigrationsAssembly("McbEdu.Mentorias.ShopDemo.WebApi")));
        
        builder.Services.AddSingleton<IAdapter<ImportCustomerPayload, ImportCustomerUseCaseInput>, AdapterImportCustomerPayloadToUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportCustomerUseCaseInput, ImportCustomerServiceInput>, AdapterImportCustomerUseCaseInputToServiceInput>();
        builder.Services.AddSingleton<IAdapter<ImportCustomerServiceInput, CustomerStandard>, AdapterImportCustomerServiceInputToCustomerStandard>();
        builder.Services.AddSingleton<IAdapter<CustomerStandard, Customer>, AdapterCustomerStandardToCustomer>();

        builder.Services.AddSingleton<IAdapter<List<NotificationItem>, List<ValidationFailure>>, AdapterValidationFailureToNotificationItem>();

        builder.Services.AddSingleton<IAdapter<ImportProductPayload, ImportProductUseCaseInput>, AdapterImportProductPayloadToUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportProductUseCaseInput, ImportProductServiceInput>, AdapterImportProductUseCaseInputToServiceInput>();
        builder.Services.AddSingleton<IAdapter<ImportProductServiceInput, ProductStandard>, AdapterImportProductServiceInputToProductStandard>();
        builder.Services.AddSingleton<IAdapter<Product, ProductStandard>, AdapterProductStandardToProductDataTransfer>();

        builder.Services.AddSingleton<IAdapter<ImportItemPayload, ImportItemUseCaseInput>, AdapterImportItemPayloadToUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportItemServiceInput, ItemStandard>, AdapterImportItemServiceInputToItemStandard>();
        builder.Services.AddSingleton<IAdapter<ItemStandard, Item>, AdapterItemStandardToItemDataTransfer>();
        builder.Services.AddSingleton<IAdapter<ImportItemUseCaseInput, ImportItemServiceInput>, AdapterImportItemUseCaseInputToServiceInput>();

        builder.Services.AddSingleton<IAdapter<List<ImportItemPayload>, List<ImportItemUseCaseInput>>, AdapterListImportItemPayloadToUseCaseList>();
        builder.Services.AddSingleton<IAdapter<List<ImportItemServiceInput>, List<ItemStandard>>, AdapterListImportItemServiceInputToListItemStandard>();
        builder.Services.AddSingleton<IAdapter<List<ImportItemUseCaseInput>, List<ImportItemServiceInput>>, AdapterListImportItemUseCaseInputToListServiceInput>();
        builder.Services.AddSingleton<IAdapter<List<ItemStandard>, List<Item>>, AdapterListItemStandardToListItemDataTransfer>();
       
        builder.Services.AddSingleton<IAdapter<ImportOrderPayload, ImportOrderUseCaseInput>, AdapterImportOrderPayloadToUseCase>();
        builder.Services.AddSingleton<IAdapter<ImportOrderUseCaseInput, ImportOrderServiceInput>, AdapterImportOrderUseCaseInputToServiceInput>();
        builder.Services.AddSingleton<IAdapter<ImportOrderServiceInput, OrderStandard>, AdapterImportOrderServiceInputToOrderStandard>();
        builder.Services.AddSingleton<IAdapter<OrderStandard, Order>, AdapterOrderStandardToOrderDataTransfer>();

        builder.Services.AddSingleton<AbstractValidator<CustomerStandard>, CustomerValidator>();
        builder.Services.AddSingleton<AbstractValidator<List<CustomerStandard>>, CustomerRangeValidator>();
        builder.Services.AddSingleton<AbstractValidator<ProductStandard>, ProductValidator>();
        builder.Services.AddSingleton<AbstractValidator<List<ProductStandard>>, ProductRangeValidator>();
        builder.Services.AddSingleton<AbstractValidator<ItemStandard>, ItemValidator>();
        builder.Services.AddSingleton<AbstractValidator<List<ItemStandard>>, ItemsValidator>();
        builder.Services.AddSingleton<AbstractValidator<OrderStandard>, OrderValidator>();

        builder.Services.AddScoped<NotifiableContainerBase<NotificationItem>, NotifiableContainer>();
        builder.Services.AddTransient<INotificationConsumer<NotificationItem>, NotificationConsumer>();
        builder.Services.AddTransient<INotificationPublisher<NotificationItem>, NotificationPublisher>();

        builder.Services.AddScoped<IBaseRepository<Order>, OrderRepository>();
        builder.Services.AddScoped<IBaseRepository<Item>, ItemRepository>();
        builder.Services.AddScoped<IExtendsCustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IExtendsProductRepository, ProductRepository>();

        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<IUseCase<ImportProductUseCaseInput>, ImportProductUseCase>();
        builder.Services.AddScoped<IUseCase<List<ImportProductUseCaseInput>>, ImportRangeProductUseCase>();
        builder.Services.AddScoped<IUseCase<ImportCustomerUseCaseInput>, ImportCustomerUseCase>();
        builder.Services.AddScoped<IUseCase<List<ImportCustomerUseCaseInput>>, ImportRangeCustomerUseCase>();
        builder.Services.AddScoped<IUseCase<ImportOrderUseCaseInput>, ImportOrderUseCase>();

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