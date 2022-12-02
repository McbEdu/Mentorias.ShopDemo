using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class OrderRepository : IBaseRepository<Order>
{
    private readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Order entity)
    {
        await _dataContext.Orders.AddAsync(entity);
        _dataContext.SaveChanges();
    }

    public Task AddRangeAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Order entity)
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAll()
    {
        throw new NotImplementedException();
    }

    public Order? GetByIdentifier(Guid identifier)
    {
        throw new NotImplementedException();
    }

    public void Update(Order entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(List<Order> entities)
    {
        throw new NotImplementedException();
    }
}
