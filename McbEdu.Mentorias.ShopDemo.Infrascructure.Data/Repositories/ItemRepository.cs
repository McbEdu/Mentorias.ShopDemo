using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class ItemRepository : IBaseRepository<Item>
{
    private readonly DataContext _dataContext;

    public ItemRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddAsync(Item entity)
    {
        return Task.FromResult(_dataContext.Items.Add(entity));  
    }

    public Task AddRangeAsync(Item entity)
    {
        throw new NotImplementedException();
    }

    public Task CommitChanges()
    {
        return Task.FromResult(_dataContext.SaveChanges());
    }

    public void Delete(Item entity)
    {
        throw new NotImplementedException();
    }

    public List<Item> GetAll()
    {
        throw new NotImplementedException();
    }

    public Item? GetByIdentifier(Guid identifier)
    {
        throw new NotImplementedException();
    }

    public void Update(Item entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(List<Item> entities)
    {
        throw new NotImplementedException();
    }
}
