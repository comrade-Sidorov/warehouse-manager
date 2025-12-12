namespace Warehouse.DAL.Repositories.Interfaces;

public interface ICommonRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetEntityById(long Id);
    Task<TEntity[]> GetEntities();
    Task Create(TEntity entity);
    Task Remove(long Id);
}