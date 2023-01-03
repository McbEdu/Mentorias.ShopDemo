using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

public interface IExtendsProductRepository : IBaseRepository<Product>
{
    Task<bool> VerifyEntityExistsAsync(string code);
    Task<bool> VerifyEntityExistsLocalAsync(string code);
    Task<Product?> GetByCode(string code);
    Task<List<Product>> GetProductByPaginationOrderringByDescription(int index, int offset);
    Task<List<Product>> GetProductByPaginationFilteredByCode(int index, int offset);
    Task<List<Product>> GetProductByPaginationFilteredByDescription(int index, int offset);
}
