using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.Users;
using DataAccess.Repository.Workout;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartWorkoutApp.Services.EmailService;
using SmartWorkoutApp.Services.ScannerService;

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
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IOcrService, OcrService>();
        return services;
    }
}