using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class OrderRepository : IBaseRepository<Order>
{
    protected readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Order entity)
    {
        await _dataContext.Orders.AddAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<Order> entity)
    {
        await _dataContext.Orders.AddRangeAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order entity)
    {
        _dataContext.Orders.Remove(entity);
        await _dataContext.SaveChangesAsync();
    }

    public Task<List<Order>> GetAllAsync()
    {
        return _dataContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetAsync(Guid identifier)
    {
        return await _dataContext.Orders.Where(p => p.Identifier == identifier).FirstAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        _dataContext.Orders.Update(entity);
        await _dataContext.SaveChangesAsync();
    }
}
