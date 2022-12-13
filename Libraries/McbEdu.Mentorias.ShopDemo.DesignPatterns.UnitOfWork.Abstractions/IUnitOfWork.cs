namespace McbEdu.Mentorias.ShopDemo.DesignPatterns.UnitOfWork.Abstractions;

public interface IUnitOfWork
{
    Task<bool> ExecuteAsync(Func<Task<bool>> handler);
}
