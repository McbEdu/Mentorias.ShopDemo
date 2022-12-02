using McbEdu.Mentorias.ShopDemo.Services.Items.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Items.Interfaces;

public interface IItemService
{
    Task<bool> ImportItemAsync(ImportItemServiceInput importItemServiceInput);
    Task<bool> VerifyItemIsRegisteredAsync(ImportItemServiceInput importItemServiceInput);
    Task<bool> VerifyItemIsValidAsync(ImportItemServiceInput importItemServiceInput);
    Task<bool> VerifyItemRangeIsValidAsync(List<ImportItemServiceInput> importItemServiceInput);
}