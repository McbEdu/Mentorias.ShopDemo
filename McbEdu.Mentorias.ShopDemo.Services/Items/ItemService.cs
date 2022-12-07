using FluentValidation;
using McbEdu.Mentorias.DesignPatterns.AdapterPattern.Abstractions;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern.Abstractions.Publisher;
using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Items.Interfaces;
using FluentValidation.Results;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Services.Items;

public class ItemService : IItemService
{
    private readonly AbstractValidator<ItemBase> _itemValidator;
    private readonly IBaseRepository<Item> _itemRepository;
    private readonly IAdapter<ImportItemServiceInput, ItemBase> _adapterItemStandard;
    private readonly IAdapter<List<ImportItemServiceInput>, List<ItemBase>> _adapterItemsStandard;
    private readonly IAdapter<ItemBase, Item> _adapterItemDataTransfer;
    private readonly INotificationPublisher<NotificationItem> _notificationPublisher;
    private readonly IAdapter<List<NotificationItem>, List<ValidationFailure>> _adapterNotifications;
    private readonly AbstractValidator<List<ItemBase>> _itemsValidator;

    public ItemService(
        AbstractValidator<ItemBase> itemValidator, 
        AbstractValidator<List<ItemBase>> itemsValidator,
        IBaseRepository<Item> itemRepository,
        IAdapter<ItemBase, Item> adapterItemDataTransfer,
        IAdapter<ImportItemServiceInput, ItemBase> adapterItemStandard,
        INotificationPublisher<NotificationItem> notificationPublisher,
        IAdapter<List<NotificationItem>, List<ValidationFailure>> adapterNotifications,
        IAdapter<List<ImportItemServiceInput>, List<ItemBase>> adapterItemsStandard)
    {
        _itemValidator = itemValidator;
        _itemRepository = itemRepository;
        _adapterItemDataTransfer = adapterItemDataTransfer;
        _adapterItemStandard = adapterItemStandard;
        _notificationPublisher = notificationPublisher;
        _adapterNotifications = adapterNotifications;
        _itemsValidator = itemsValidator;
        _adapterItemsStandard = adapterItemsStandard;
    }

    public Task<bool> ImportItemAsync(ImportItemServiceInput importItemServiceInput)
    {
        var adaptedItem = _adapterItemStandard.Adapt(importItemServiceInput);

        _itemRepository.AddAsync(_adapterItemDataTransfer.Adapt(adaptedItem));

        return Task.FromResult(true);
    }

    public Task<bool> VerifyItemIsRegisteredAsync(ImportItemServiceInput importItemServiceInput)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyItemIsValidAsync(ImportItemServiceInput importItemServiceInput)
    {
        var adaptedStandardItem = _adapterItemStandard.Adapt(importItemServiceInput);

        var validationResult = _itemValidator.Validate(adaptedStandardItem);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    public Task<bool> VerifyItemRangeIsValidAsync(List<ImportItemServiceInput> importItemServiceInput)
    {
        var adaptedStandardItem = _adapterItemsStandard.Adapt(importItemServiceInput);

        var validationResult = _itemsValidator.Validate(adaptedStandardItem);

        if (validationResult.IsValid == false)
        {
            _notificationPublisher.AddNotifications(_adapterNotifications.Adapt(validationResult.Errors));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}
