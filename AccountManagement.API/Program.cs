using AccountManagement.API.Application.Infrastructure;
using AccountManagement.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using static AccountManagement.API.Application.Infrastructure.CustomExtensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.RegisterRepos(builder.Configuration);
builder.Services.RegisterServices();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Account Management API", Version = "v1" });
});

var app = builder.Build();

app.ConfigureSwagger();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
