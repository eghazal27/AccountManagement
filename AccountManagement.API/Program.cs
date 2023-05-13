using AccountManagement.API.Application.Infrastructure;
using Microsoft.OpenApi.Models;
using static AccountManagement.API.Application.Infrastructure.CustomExtensions;
using AccountManagement.Service.Application.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.RegisterDBContextAndRepos(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.EnableCORS();
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
app.UseCors();
app.SeedData();


app.Run();
