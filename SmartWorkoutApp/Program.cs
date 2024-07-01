using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.Exercises;
using DataAccess.Repository.Users;
using DataAccess.Repository.Workout;
using Microsoft.EntityFrameworkCore;
using SmartWorkoutApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var configuration = builder.Configuration;
var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();