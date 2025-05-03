using System.Reflection;
using Core;
using Core.Interfaces;
using Data;
using Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_Api_Football_SPR311;
using Web_Api_Football_SPR311.Extensions;
using Web_Api_Football_SPR311.Interfaces;
using Web_Api_Football_SPR311.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connStr = builder.Configuration.GetConnectionString("SomeeDb");

builder.Services.AddIdentity<User, IdentityRole>(options => 
        options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<FootballDbContext>();

builder.Services.AddDbContext<FootballDbContext>(opts => 
    opts.UseSqlServer(connStr));

builder.Services.AddScoped<IEmailSender, EmailService>();

builder.Services.AddScoped<FavouritesServiceLocal>();
builder.Services.AddScoped<FavouritesServiceDb>();
builder.Services.AddScoped<IFavoriteService>(provider =>
{
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    var user = httpContextAccessor.HttpContext?.User;

    var isAuthenticated = user?.Identity?.IsAuthenticated ?? false;

    if (isAuthenticated)
        return provider.GetRequiredService<FavouritesServiceDb>();
    else
        return provider.GetRequiredService<FavouritesServiceLocal>();
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<CreateTeamValidation>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(7);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedRoles().Wait();
    scope.ServiceProvider.SeedAdmin().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSession();

app.MapControllers();

app.Run();