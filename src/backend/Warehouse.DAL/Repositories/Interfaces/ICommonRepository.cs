using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Repositories.Interfaces;

public interface ICommonRepository<TEntity> where TEntity : CommonEntity
{
    Task<TEntity?> GetEntityByIdAsync(long id);
    Task<TEntity[]> GetEntitiesAsync();
    Task CreateAsync(TEntity entity);
    Task RemoveAsync(long id);
    Task SaveChangesAsync();
}