using FluentValidation.Results;
using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct.Inputs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateRangeProduct;

public class CreateRangeProductHandler : HandlerBase<CreateRangeProductResponse, CreateRangeProductRequest>
{
    private readonly IExtendsRepository<Product> _productExtendsRepository;
    private readonly AbstractValidator<ProductBase> _productValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly NotifiablePublisherStandard _notifiablePublisherStandard;
    private readonly IAdapter<ProductStandard, CreateProductInputModel> _adapterProductInputModelToStandard;
    private readonly IAdapter<Product, ProductStandard> _adapterProductStandardToProductDTO;

    public CreateRangeProductHandler(IExtendsRepository<Product> productExtendsRepository, AbstractValidator<ProductBase> productValidator,
        IAdapter<List<NotificationItemBase>, List<ValidationFailure>> adapterNotifications, NotifiablePublisherStandard notifiablePublisherStandard,
        IAdapter<ProductStandard, CreateProductInputModel> adapterProductInputModelToStandard, IAdapter<Product, ProductStandard> adapterProductStandardToProductDTO)
    {
        _productExtendsRepository = productExtendsRepository;
        _productValidator = productValidator;
        _adapterNotifications = adapterNotifications;
        _notifiablePublisherStandard = notifiablePublisherStandard;
        _adapterProductInputModelToStandard = adapterProductInputModelToStandard;
        _adapterProductStandardToProductDTO = adapterProductStandardToProductDTO;
    }

    public async override Task<CreateRangeProductResponse> Handle(CreateRangeProductRequest request)
    {
        var productsStandardList = new List<ProductStandard>();

        if (productsStandardList.Count < 1)
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Lista de Produtos", "É necessário enviar uma lista de produtos válida!"));
            return new CreateRangeProductResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário exibir uma lista de produtos para realizar a importação em lote.");
        }

        foreach (var productInput in request.InputModels)
        {
            var productAdaptee = _adapterProductInputModelToStandard.Adapt(productInput);
            var validation = _productValidator.Validate(productAdaptee);

            if (validation.IsValid == false)
            {
                _notifiablePublisherStandard.AddNotifications(_adapterNotifications.Adapt(validation.Errors));
                return new CreateRangeProductResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "É necessário importar uma lista de clientes válida!");
            }

            productsStandardList.Add(productAdaptee);
        }

        var productsDataTransferList = new List<Product>();
        foreach (var productStandard in productsStandardList)
        {
            productsDataTransferList.Add(_adapterProductStandardToProductDTO.Adapt(productStandard));
        }

        await _productExtendsRepository.AddRangeAsync(productsDataTransferList);

        return new CreateRangeProductResponse(new HttpResponse(TypeHttpStatusCodeResponse.Created), request.RequestedOn, "Todos os produtos foram importados com sucesso!");
    }
}
