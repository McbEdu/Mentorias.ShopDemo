using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class CustomerRepository : IExtendsCustomerRepository
{
    private readonly DataContext _dataContext;

    public CustomerRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Customer entity)
    {
        await _dataContext.Customers.AddAsync(entity);
    }

    public async Task AddRangeAsync(Customer entity)
    {
        await _dataContext.Customers.AddRangeAsync(entity);
    }

    public Task CommitChanges()
    {
        return Task.FromResult(_dataContext.SaveChanges());
    }

    public void Delete(Customer entity)
    {
        _dataContext.Customers.Remove(entity);
    }

    public List<Customer> GetAll()
    {
        return _dataContext.Customers.ToList();
    }

    public async Task<Customer> GetByEmail(string email)
    {
        return await _dataContext.Customers.Where(p => p.Email == email).FirstAsync();
    }

    public Customer? GetByIdentifier(Guid identifier)
    {
        return _dataContext.Customers.Where(p => p.Identifier == identifier).FirstOrDefault();
    }

    public void Update(Customer entity)
    {
        _dataContext.Customers.Update(entity);
    }

    public void UpdateRange(List<Customer> entities)
    {
        _dataContext.Customers.UpdateRange(entities);
    }

    public async Task<bool> VerifyEntityExistsAsync(string email)
    {
        return await _dataContext.Customers.Where(p => p.Email == email).AnyAsync();
    }

    public Task<bool> VerifyEntityExistsLocalAsync(string email)
    {
        return _dataContext.Set<Customer>().Local.Where(p => p.Email == email).First().Any();
    }
}
