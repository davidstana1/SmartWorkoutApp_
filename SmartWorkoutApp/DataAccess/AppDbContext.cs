using System.Data.Common;
using DataAccess.Entities;
using DataAccess.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public AppDbContext()
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Workout> Workouts { get; set; } 
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseLog> ExerciseLogs { get; set; }

}