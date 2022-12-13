using McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;
using McbEdu.Mentorias.ShopDemo.Infrascructure.Data;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.UnitOfWork;

public class DefaultUnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    public DefaultUnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> ExecuteAsync(Func<Task<bool>> handler)
    {
        if(await handler() == true)
        {
            _dataContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}

