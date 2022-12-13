using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories.Interfaces;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class OrderRepository : IExtendsOrderRepository
{
    private readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Order entity)
    {
        await _dataContext.Orders.AddAsync(entity);
    }

    public Task AddRangeAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task CommitChanges()
    {
        return Task.FromResult(_dataContext.SaveChanges());
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

    public Task<bool> VerifyOrderIsRegisteredByCode(string code)
    {
        return Task.FromResult(_dataContext.Orders.Where(p => p.Code == code).Any());
    }
}
