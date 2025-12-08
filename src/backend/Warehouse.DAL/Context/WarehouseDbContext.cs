using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Context;

public class WarehouseDbContext : DbContext
{
    DbSet<User> Users { get; set; }
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
}