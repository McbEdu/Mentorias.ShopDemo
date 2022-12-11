namespace McbEdu.Mentorias.General.Infrascructure.Abstractions.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    void UpdateRange(List<TEntity> entities);
    TEntity? GetByIdentifier(Guid identifier);
    List<TEntity> GetAll();
    Task CommitChanges();
}
