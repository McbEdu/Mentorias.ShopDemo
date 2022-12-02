using FluentValidation;
using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using McbEdu.Mentorias.ShopDemo.Domain.Entities;
using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;
using McbEdu.Mentorias.ShopDemo.Services.Items.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Services.Items;

public class ItemService : IItemService
{
    private readonly AbstractValidator<ItemStandard> _itemValidator;
    private readonly IBaseRepository<Item> _itemRepository;

    public ItemService(AbstractValidator<ItemStandard> itemValidator, IBaseRepository<Item> itemRepository)
    {
        _itemValidator = itemValidator;
        _itemRepository = itemRepository;
    }

    public Task<bool> ImportItemAsync(ImportItemServiceInput importItemServiceInput)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyItemIsRegisteredAsync(ImportItemServiceInput importItemServiceInput)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyItemIsValidAsync(ImportItemServiceInput importItemServiceInput)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyItemRangeIsValidAsync(List<ImportItemServiceInput> importItemServiceInput)
    {
        throw new NotImplementedException();
    }
}
