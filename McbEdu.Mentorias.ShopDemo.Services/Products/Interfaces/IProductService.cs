using McbEdu.Mentorias.DesignPatterns.NotificationPattern;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Services.Products.Inputs;

namespace McbEdu.Mentorias.ShopDemo.Services.Products.Interfaces;

public interface IProductService
{
    Task<(bool, List<NotificationItem>)> ImportProductAsync(ImportProductServiceInput input);
}
