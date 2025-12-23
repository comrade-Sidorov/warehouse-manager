using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.DAL.Context;
using Warehouse.DAL.Entities;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Repositories.Impl;

public class CommonRepository<TEntity> : ICommonRepository<TEntity> where TEntity : CommonEntity
{
    private readonly WarehouseDbContext _context;
    private readonly ILogger<CommonRepository<TEntity>> _logger;

    public CommonRepository(
        WarehouseDbContext context,
        ILogger<CommonRepository<TEntity>> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task Create(TEntity entity)
    {
        if(entity is not null)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TEntity[]> GetEntitiesAsync()
    {
        return await _context.Set<TEntity>().ToArrayAsync();
    }

    public async Task<TEntity?> GetEntityByIdAsync(long id)
    {
        _logger.LogInformation($"Get {typeof(TEntity)} by id: {id}");
        return await _context.Set<TEntity>().Where(w => w.Id == id).FirstOrDefaultAsync();
    }

    public async Task Remove(long id)
    {
        var entity = await _context.Set<TEntity>().Where(w => w.Id == id).FirstOrDefaultAsync();
        if(entity is not null)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}