using System.Data.Common;
using DataAccess.Configuration;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
        
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new WorkoutConfiguration().Configure(modelBuilder.Entity<Workout>());
    }
}