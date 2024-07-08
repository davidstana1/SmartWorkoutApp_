using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.Exercises;
using DataAccess.Repository.Users;
using DataAccess.Repository.Workout;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SmartWorkoutApp;
using SmartWorkoutApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var services = builder.Services;
services.AddRepositories(configuration);

services.AddRazorComponents()
    .AddInteractiveServerComponents();


services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/Login";
        options.Cookie.MaxAge=TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/AccessDenied";
    });
services.AddHttpContextAccessor();
services.AddAuthorization();
services.AddCascadingAuthenticationState();
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
app.UseRouting();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();