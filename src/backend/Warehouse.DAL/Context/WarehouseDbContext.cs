using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Entities;

namespace Warehouse.DAL.Context;
// TODO implement soft delete for recovery user with role
public class WarehouseDbContext : DbContext
{
    DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Measure> Measures { get; set; }
    public DbSet<AdmissionDocument> AdmissionDocuments { get; set; }
    public DbSet<AdmissionResource> AdmissionResources { get; set; }
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

            if(!context.Set<Resource>().Any())
            {
                var resources = new Resource[]
                {
                    new Resource
                    {
                        Name = "Apple",
                    },

                   new Resource
                   {
                       Name = "Vodka",
                   },

                   new Resource
                   {
                       Name = "Beer",
                   }
                };

                context.Set<Resource>().AddRange(resources);
                context.SaveChanges();
            }

            if(!context.Set<Measure>().Any())
            {
                var measures = new Measure[]
                {
                    new Measure
                    {
                        Name = "Liter",
                    },

                    new Measure
                    {
                        Name = "Kilogram",
                    }
                };

                context.Set<Measure>().AddRange(measures);
                context.SaveChanges();
            }

            if(!context.Set<AdmissionDocument>().Any())
            {
                var docs = new AdmissionDocument[]
                {
                    new AdmissionDocument()
                    {
                        Number = 1
                    },

                    new AdmissionDocument()
                    {
                        Number = 2
                    },
                    new AdmissionDocument()
                    {
                        Number = 3
                    }
                };

                context.Set<AdmissionDocument>().AddRange(docs);
                context.SaveChanges();
            }

            if(!context.Set<AdmissionResource>().Any())
            {
                var admissionResources = new AdmissionResource[]
                {
                    new AdmissionResource
                    {
                        ResourceId = 1,
                        MeasureId = 2
                    },

                    new AdmissionResource
                    {
                        ResourceId = 2,
                        MeasureId = 1
                    }
                };

                context.Set<AdmissionResource>().AddRange(admissionResources);
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
        
        modelBuilder.Entity<Resource>().ToTable(nameof(Resources));

        modelBuilder.Entity<Resource>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Resource>()
            .Property(p => p.Id).HasColumnName(nameof(Resource.Id));
        modelBuilder.Entity<Resource>()
            .Property(p => p.Name).HasColumnName(nameof(Resource.Name)).IsRequired();
        modelBuilder.Entity<Resource>()
            .Property(p => p.State).HasDefaultValue(0).HasColumnName(nameof(Resource.State));
        
        modelBuilder.Entity<Measure>().ToTable(nameof(Measures));

        modelBuilder.Entity<Measure>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Measure>()
            .Property(p => p.Id).HasColumnName(nameof(Measure.Id));
        modelBuilder.Entity<Measure>()
            .Property(p => p.Name).HasColumnName(nameof(Measure.Name));
        modelBuilder.Entity<Measure>()
            .Property(p => p.State).HasDefaultValue(0).HasColumnName(nameof(Measure.State));
        modelBuilder.Entity<Measure>().HasMany(e => e.Resources).WithMany(e => e.Measures).UsingEntity<AdmissionResource>();
        
        modelBuilder.Entity<AdmissionDocument>().ToTable(nameof(AdmissionDocuments));

        modelBuilder.Entity<AdmissionDocument>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<AdmissionDocument>()
            .Property(p => p.Id).HasColumnName(nameof(AdmissionDocument.Id));
        modelBuilder.Entity<AdmissionDocument>()
            .Property(p => p.Number).HasColumnName(nameof(AdmissionDocument.Number));
        modelBuilder.Entity<AdmissionDocument>()
            .Property(p => p.Date).HasDefaultValue(DateTime.UtcNow).HasColumnName(nameof(AdmissionDocument.Date));
        
        modelBuilder.Entity<AdmissionResource>().ToTable(nameof(AdmissionResources));
        
        modelBuilder.Entity<AdmissionResource>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<AdmissionResource>()
            .Property(p => p.Id).HasColumnName(nameof(AdmissionResource.Id));
        modelBuilder.Entity<AdmissionResource>()
            .Property(p => p.ResourceId).HasColumnName(nameof(AdmissionResource.ResourceId));
        modelBuilder.Entity<AdmissionResource>()
            .Property(p => p.MeasureId).HasColumnName(nameof(AdmissionResource.MeasureId));
        modelBuilder.Entity<AdmissionResource>()
            .Property(p => p.Count).HasDefaultValue(1).HasColumnName(nameof(AdmissionResource.Count));
    }
}