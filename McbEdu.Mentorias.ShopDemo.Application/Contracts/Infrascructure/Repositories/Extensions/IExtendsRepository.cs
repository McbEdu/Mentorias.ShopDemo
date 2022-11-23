namespace McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Repositories.Extensions;

public interface IExtendsRepository<T> : IBaseRepository<T> where T : class
{
    public Task<bool> VerifyEntityExistsAsync(string information);
    public Task<bool> VerifyEntityExistsAsync(Guid identifier);
    public Task<T?> GetAsync(string information);
}
