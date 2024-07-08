using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.Workout;
using Microsoft.EntityFrameworkCore;

namespace SmartWorkoutApp;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        services.AddScoped<IGenericRepository<Workout>, GenericRepository<Workout>>();
        services.AddScoped<IGenericRepository<Exercise>, GenericRepository<Exercise>>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();

        return services;
    }
}