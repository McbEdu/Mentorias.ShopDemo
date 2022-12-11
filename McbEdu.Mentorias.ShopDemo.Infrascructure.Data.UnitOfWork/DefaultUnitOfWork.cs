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

    public async Task<bool> ExecuteAsync(Func<bool, Task<bool>> handler, bool openTransaction)
    {
        if(await handler(openTransaction) == true)
        {
            _dataContext.SaveChanges();
            return true;
        }
        else
        {
            _dataContext.Dispose();
            return false;
        }
    }
}
