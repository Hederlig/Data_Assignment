using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
    public DbSet<ActivityStatusEntity> ActivityStatus { get; set; }
    //public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    //public DbSet<UserEntity> Users { get; set; }

    // Overrides
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ActivityStatusEntity>().HasData(
            new ActivityStatusEntity { Id = 1, Status = "Not Started" },
            new ActivityStatusEntity { Id = 2, Status = "In Progress" },
            new ActivityStatusEntity { Id = 3, Status = "Completed" }
            );
        }
    }
