using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Context;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Repositories.Impl;

public class CommonRepository<TEntity> : ICommonRepository<TEntity> where TEntity : CommonEntity
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

    public async Task<TEntity?> GetEntityById(long id)
    {
        return await _context.Set<TEntity>().Where(w => w.Id == id).FirstOrDefaultAsync();
    }

    public async Task Remove(long id)
    {
        var entity = await _context.Set<TEntity>().Where(w => w.Id == id).FirstOrDefaultAsync();
        if(entity is not null)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}