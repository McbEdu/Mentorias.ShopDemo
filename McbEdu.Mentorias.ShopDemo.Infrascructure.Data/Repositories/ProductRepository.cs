﻿using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class ProductRepository : IExtendsProductRepository
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddAsync(Product entity)
    {
        return Task.FromResult(_dataContext.Products.Add(entity));   
    }

    public Task AddRangeAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task CommitChanges()
    {
        return Task.FromResult(_dataContext.SaveChanges());
    }

    public void Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByCode(string code)
    {
        return Task.FromResult(_dataContext.Products.Where(p => p.Code == code).FirstOrDefault());
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

    public Task<bool> VerifyEntityExistsAsync(string code)
    {
        return Task.FromResult(_dataContext.Products.Where(p => p.Code == code).Any());
    }

    public Task<bool> VerifyEntityExistsLocalAsync(string code)
    {
        return _dataContext.Set<Product>().Local.Where(p => p.Code == code).First().Any();
    }
}
