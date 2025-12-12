using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Context;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Repositories.Impl;

public class CommonRepository<TEntity> : ICommonRepository<TEntity> where TEntity : class
{
    private readonly WarehouseDbContext _context;

    public CommonRepository(
        WarehouseDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task Create(TEntity entity)
    {
        if(entity is not null)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task<TEntity[]> GetEntities()
    {
        return await _context.Set<TEntity>().ToArrayAsync();
    }

    public async Task<TEntity> GetEntityById(long Id)
    {
        object id = (object)Id;
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task Remove(long Id)
    {
        object id = (object)Id;
        var r = await _context.Set<TEntity>().FindAsync(id);
        _context.Set<TEntity>().Remove(r);
    }
}