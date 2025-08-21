using Microsoft.EntityFrameworkCore;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.Infrastructure;

public class WarehouseContext : DbContext
{
    public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
    { }
    public DbSet<TestEntity> TestEntities { get; set; }
}
