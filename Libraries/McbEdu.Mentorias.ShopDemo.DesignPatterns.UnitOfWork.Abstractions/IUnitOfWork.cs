namespace McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;

public interface IUnitOfWork
{
    Task<bool> ExecuteAsync(Func<bool, Task<bool>> handler, bool openTransaction);
}
