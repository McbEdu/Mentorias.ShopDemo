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
using McbEdu.Mentorias.ShopDemo.Domain.Models.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Models.ENUMs;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct;

public class CreateProductHandler : HandlerBase<CreateProductResponse, CreateProductRequest>
{
    private readonly IExtendsRepository<Product> _productExtendsRepository;
    private readonly AbstractValidator<ProductBase> _productValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly NotifiablePublisherStandard _notifiablePublisherStandard;
    private readonly IAdapter<ProductStandard, CreateProductInputModel> _adapterProductInputModelToStandard;
    private readonly IAdapter<Product, ProductStandard> _adapterProductStandardToProductDTO;

    public CreateProductHandler(IExtendsRepository<Product> productExtendsRepository, AbstractValidator<ProductBase> productValidator,
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

    public async override Task<CreateProductResponse> Handle(CreateProductRequest request)
    {
        var productAdaptee = _adapterProductInputModelToStandard.Adapt(request.InputModel);

        var validation = _productValidator.Validate(productAdaptee);

        if (validation.IsValid == false)
        {
            return new CreateProductResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "O produto é inválido!");
        }

        if (await _productExtendsRepository.VerifyEntityExistsAsync(request.InputModel.Code))
        {
            _notifiablePublisherStandard.AddNotification(new NotificationItemStandard("Produto", "O produto já existe!"));
            return new CreateProductResponse(new HttpResponse(TypeHttpStatusCodeResponse.BadRequest), request.RequestedOn, "O produto já existe no banco de dados");
        }

        await _productExtendsRepository.AddAsync(_adapterProductStandardToProductDTO.Adapt(productAdaptee));

        return new CreateProductResponse(new HttpResponse(TypeHttpStatusCodeResponse.Created), request.RequestedOn, "Produto cadastrado com sucesso!");
    }
}
