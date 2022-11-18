using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class ProductRepository : IBaseRepository<Product>
{
    protected readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Product entity)
    {
        await _dataContext.Products.AddAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<Product> entity)
    {
        await _dataContext.Products.AddRangeAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product entity)
    {
        _dataContext.Products.Remove(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        if (_dataContext.Products is null) return new List<Product>();

        return await _dataContext.Products.ToListAsync();
    }

    public async Task<Product?> GetAsync(Guid identifier)
    {
        if (_dataContext.Products is null) return null;

        return await _dataContext.Products.Where(p => p.Identifier == identifier).FirstOrDefaultAsync(); 
    }

    public async Task UpdateAsync(Product entity)
    {
        _dataContext.Products.Update(entity);
        await _dataContext.SaveChangesAsync();
    }
}
