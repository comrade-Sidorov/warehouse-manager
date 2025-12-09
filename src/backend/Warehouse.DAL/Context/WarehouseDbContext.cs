using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Context;
// TODO implement soft delete for recovery user with role
public class WarehouseDbContext : DbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Note> Notes { get; set; }
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            if(!context.Set<User>().Any())
            {
                var user = new User
                {
                    Name = "test",
                    Age = 1
                };

                context.Set<User>().Add(user);
                context.SaveChanges();
            }
            
            if(!context.Set<Note>().Any())
            {
                var note = new Note
                {
                    Value = "draft"
                };

                context.Set<Note>().Add(note);
                context.SaveChanges();
            }
        });
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable(nameof(Users));

        modelBuilder.Entity<User>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<User>()
            .Property(p => p.Id).HasColumnName(nameof(User.Id));
        modelBuilder.Entity<User>()
            .Property(p => p.Name).HasColumnName(nameof(User.Name)).IsRequired();
        modelBuilder.Entity<User>()
            .Property(p => p.Age).HasColumnName(nameof(User.Age));
        
        modelBuilder.Entity<Note>().ToTable(nameof(Notes));

        modelBuilder.Entity<Note>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Note>()
            .Property(p => p.Id).HasColumnName(nameof(Note.Id));
        modelBuilder.Entity<Note>()
            .Property(p => p.Value).HasColumnName(nameof(Note.Value)).IsRequired();
        modelBuilder.Entity<Note>()
            .Property(p => p.ChangedTime).HasDefaultValue(DateTime.UtcNow).HasColumnName(nameof(Note.ChangedTime));
        
    }
}