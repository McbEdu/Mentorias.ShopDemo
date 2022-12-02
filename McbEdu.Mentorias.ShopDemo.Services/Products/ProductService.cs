using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Validators;
using FluentValidation;

namespace McbEdu.Mentorias.ShopDemo.Services.Products;

public class ProductService : IProductService
{
    private readonly IExtendsProductRepository _productRepository;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<ImportProductServiceInput, ProductStandard> _adapter;
    private readonly IAdapter<Product, ProductStandard> _adapterDataTransfer;
    private readonly AbstractValidator<ProductStandard> _productValidator;
    private readonly AbstractValidator<List<ProductStandard>> _productRangeValidator;

    public ProductService(
        IExtendsProductRepository productRepository, 
        INotificationPublisher<NotificationItem> notificationPublisher,
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications,
        IAdapter<ImportProductServiceInput, ProductStandard> adapter,
        IAdapter<Product, ProductStandard> adapterDataTransfer,
        AbstractValidator<ProductStandard> productValidator,
        AbstractValidator<List<ProductStandard>> productRangeValidator)
    {
        _productRepository = productRepository;
        _notificationPublisher = notificationPublisher;
        _adapterNotifications = adapterNotifications;
        _adapter = adapter;
        _adapterDataTransfer = adapterDataTransfer;
        _productValidator = productValidator;
        _productRangeValidator = productRangeValidator;
    }

    public async Task<Product> GetProductByCodeAsync(string code)
    {
        return await _productRepository.GetByCode(code);
    }

    public async Task<bool> ImportProductAsync(ImportProductServiceInput input)
    {
        var productStandard = _adapter.Adapt(input);

        await _productRepository.AddAsync(_adapterDataTransfer.Adapt(productStandard));

        return true;
    }

    public Task<bool> VerifyProductIsRegisteredAsync(ImportProductServiceInput input)
    {
        return _productRepository.VerifyEntityExistsAsync(input.Code);
    }

    public Task<bool> VerifyProductIsValidAsync(ImportProductServiceInput input)
    {
        var productStandard = _adapter.Adapt(input);

        var validationResult = _productValidator.Validate(productStandard);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    public Task<bool> VerifyProductRangeIsValidAsync(List<ImportProductServiceInput> input)
    {
        var productStandardList = new List<ProductStandard>();

        foreach (var uniqueProductStandard in input)
        {
            productStandardList.Add(_adapter.Adapt(uniqueProductStandard));
        }

        var validationResult = _productRangeValidator.Validate(productStandardList);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}
