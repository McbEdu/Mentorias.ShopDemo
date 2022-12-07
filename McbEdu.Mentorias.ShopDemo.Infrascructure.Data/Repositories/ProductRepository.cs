using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class ProductRepository : IExtendsProductRepository
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Product entity)
    {
        await _dataContext.Products.AddAsync(entity);   
        _dataContext.SaveChanges();
    }

    public Task AddRangeAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetByCode(string code)
    {
        return await _dataContext.Products.Where(p => p.Code == code)!.FirstOrDefaultAsync();
    }

    public Product? GetByIdentifier(Guid identifier)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(List<Product> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> VerifyEntityExistsAsync(string code)
    {
        return await _dataContext.Products.Where(p => p.Code == code).AnyAsync();
    }
}
