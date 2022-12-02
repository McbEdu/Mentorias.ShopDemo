using McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Repositories;

public class ItemRepository : IBaseRepository<Item>
{
    private readonly DataContext _dataContext;

    public ItemRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Item entity)
    {
        await _dataContext.Items.AddAsync(entity);  
        _dataContext.SaveChanges();
    }

    public Task AddRangeAsync(Item entity)
    {
        throw new NotImplementedException();
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
