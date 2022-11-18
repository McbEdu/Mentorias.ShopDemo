using FluentValidation.Results;
using FluentValidation;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Adapters;
using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Services.Handlers;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Items;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities.Notification.Publisher;
using McbEdu.Mentorias.ShopDemo.Domain.Models.Entities;

namespace McbEdu.Mentorias.ShopDemo.Services.Handlers.CreateProduct;

public class CreateProductHandler : HandlerBase<CreateProductResponse, CreateProductRequest>
{
    private readonly IExtendsRepository<Product> _productExtendsRepository;
    private readonly AbstractValidator<ProductBase> _productValidator;
    private readonly IAdapter<List<NotificationItemBase>, List<ValidationFailure>> _adapterNotifications;
    private readonly NotifiablePublisherStandard _notifiablePublisherStandard;

    public CreateProductHandler(IExtendsRepository<Product> productExtendsRepository, AbstractValidator<ProductBase> productValidator,
        IAdapter<List<NotificationItemBase>, List<ValidationFailure>> adapterNotifications, NotifiablePublisherStandard notifiablePublisherStandard)
    {
        _productExtendsRepository = productExtendsRepository;
        _productValidator = productValidator;
        _adapterNotifications = adapterNotifications;
        _notifiablePublisherStandard = notifiablePublisherStandard;
    }

    public override Task<CreateProductResponse> Handle(CreateProductRequest request)
    {
        throw new NotImplementedException();
    }
}
