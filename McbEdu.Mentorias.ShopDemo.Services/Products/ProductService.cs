using FluentValidation;
using FluentValidation.Results;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Products;

public class ProductService : IProductService
{
    private readonly IExtendsProductRepository _productRepository;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;
    private readonly IAdapter<ImportProductServiceInput, ProductBase> _adapter;
    private readonly IAdapter<Product, ProductBase> _adapterDataTransfer;
    private readonly AbstractValidator<ProductBase> _productValidator;

    public ProductService(
        IExtendsProductRepository productRepository, 
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications,
        IAdapter<ImportProductServiceInput, ProductBase> adapter,
        IAdapter<Product, ProductBase> adapterDataTransfer,
        AbstractValidator<ProductBase> productValidator)
    {
        _productRepository = productRepository;
        _adapterNotifications = adapterNotifications;
        _adapter = adapter;
        _adapterDataTransfer = adapterDataTransfer;
        _productValidator = productValidator;
    }

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, List<Product> Products)> GetProductsAsync(GetProductServiceInput input)
    {
        var notifications = new List<NotificationItem>();
        var products = new List<Product>();

        if (input.Page < 1)
        {
            notifications.Add(new NotificationItem("A página precisa ser maior ou igual que 1"));
            return (false, notifications, products);
        }

        if (input.Offset > 30)
        {
            notifications.Add(new NotificationItem("A quantidade de clientes por paginação a ser retornada por cliente tem que ser menor que 30."));
            return (false, notifications, products);
        }

        var indexCalculation = (input.Page - 1) * input.Offset;

        if (input.Type == TypeGetProductService.NoFilter)
        {
            products = await _productRepository.GetProductByPaginationOrderringByDescription(indexCalculation, input.Offset);
        }
        else if (input.Type == TypeGetProductService.FilteredByCode)
        {
            products = await _productRepository.GetProductByPaginationFilteredByCode(indexCalculation, input.Offset);
        }
        else if (input.Type == TypeGetProductService.FilteredByDescription)
        {
            products = await _productRepository.GetProductByPaginationFilteredByDescription(indexCalculation, input.Offset);
        }
        else
        {
            throw new Exception("Não existe nenhum caracterizado por esse valor inteiro.");
        }

        return (true, notifications, products);
    }

    public async Task<(bool, List<NotificationItem>)> ImportProductAsync(ImportProductServiceInput input)
    {
        var notifications = new List<NotificationItem>();
        var productStandard = _adapter.Adapt(input);

        var validationResult = _productValidator.Validate(productStandard);

        // Validações da regra de negócios
        if (validationResult.IsValid == false)
        {
            notifications.AddRange(_adapterNotifications.Adapt(validationResult.Errors));
            return (false, notifications);
        }
            
        // Verifica se existe no banco de dados
        if (await _productRepository.VerifyEntityExistsAsync(input.Code) == true)
        {
            notifications.Add(new NotificationItem("O produto já está importado."));
            return (false, notifications);
        }

        // Verifica se dois produtos ou mais estão na fila
        if (await _productRepository.VerifyEntityExistsLocalAsync(input.Code) == true)
        {
            notifications.Add(new NotificationItem("Não é possível importar dois produtos com mesmo código."));
            return (false, notifications);
        }

        // Põe em memória, esperando salvamento de mudanças pelo banco de dados.
        await _productRepository.AddAsync(_adapterDataTransfer.Adapt(productStandard));

        return (true, notifications);
    }
}
