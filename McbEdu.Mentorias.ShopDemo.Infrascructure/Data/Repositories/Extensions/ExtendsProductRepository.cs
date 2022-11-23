using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Extensions;

public class ExtendsProductRepository : ProductRepository, IExtendsRepository<Product>
{
    public ExtendsProductRepository(DataContext dataContext) : base(dataContext)
    {

    }

    public async Task<Product?> GetAsync(string information)
    {
        if (_dataContext.Products is null) return null;

        return await _dataContext.Products.Where(p => p.Code == information).FirstAsync();
    }

    public async Task<bool> VerifyEntityExistsAsync(string information)
    {
        if (_dataContext.Products is null) return false;

        return await _dataContext.Products.AnyAsync(p => p.Code == information);
    }

    public async Task<bool> VerifyEntityExistsAsync(Guid identifier)
    {
        if (_dataContext.Products is null) return false;

        return await _dataContext.Products.AnyAsync(p => p.Identifier == identifier);
    }
}
