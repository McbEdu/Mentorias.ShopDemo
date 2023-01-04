using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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

    public Task<List<Customer>> GetCustomerByPaginationFilteredByEmail(string email, int index, int offset)
    {
        return _dataContext.Customers.AsNoTracking().Skip(index * offset).Take(offset).Where(p => p.Email.Contains(email)).ToListAsync();
    }

    public Task<List<Customer>> GetCustomerByPaginationFilteredByNameOrSurname(string name, string surname, int index, int offset)
    {
        return _dataContext.Customers.AsNoTracking().Skip(index * offset).Take(offset).Where(p => p.Name.Contains(name) || p.Surname.Contains(surname)).ToListAsync();
    }

    public Task<List<Customer>> GetCustomerByPaginationFilteredByRangeBirthDate(DateTime startIn, DateTime startFinal, int index, int offset)
    {
        return _dataContext.Customers.AsNoTracking().Skip(index * offset).Take(offset).Where(p => p.BirthDate.Date >= startIn.Date && p.BirthDate.Date <= startFinal.Date).ToListAsync();
    }

    public async Task<List<Customer>> GetCustomerByPaginationOrderringByNameAndSurnameAsync(int index, int offset)
    {
        return await _dataContext.Customers.AsNoTracking().Skip(index*offset).Take(offset).OrderBy(p => p.Name).OrderBy(p => p.Surname).ToListAsync();
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
        return Task.FromResult(_dataContext.Set<Customer>().Local.Where(p => p.Email == email).Any());
    }
}
