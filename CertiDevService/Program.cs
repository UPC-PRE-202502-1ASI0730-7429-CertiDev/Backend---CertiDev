using CertiDevService.Modules.Owners.Application.Services;
using CertiDevService.Modules.Owners.Infrastructure.Repositories;
using CertiDevService.Modules.Buyers.Application.Services;
using CertiDevService.Modules.Buyers.Infrastructure.Repositories;
using CertiDevService.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);

// 1. Conexión a base de datos (ajusta la cadena en appsettings.json)
builder.Services.AddDbContext<CertiDevDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Servicios y Repositorios (registra las implementaciones)
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<OwnerService>();

builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
builder.Services.AddScoped<BuyerService>();

// 3. Controllers, swagger y CORS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CertiDevService API", Version = "v1" });
});

// (opcional) permitir CORS mientras desarrollas frontend local
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CertiDevService API v1");
    c.RoutePrefix = string.Empty; // Swagger en la raíz
});


app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();