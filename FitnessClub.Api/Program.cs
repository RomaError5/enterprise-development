using System.Text.Json.Serialization;
using FitnessClub.Api.Infrastructure;
using FitnessClub.Application;
using FitnessClub.Infrastructure.InMemory;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Хранилище (InMemory): seed-данные и репозитории
builder.Services.AddInMemoryRepositories();

// CRUD- и аналитические сервисы
builder.Services.AddApplicationServices();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Swagger с XML-комментариями всех сборок решения
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FitnessClub API",
        Version = "v1",
        Description = "REST API фитнес-клуба: CRUD-операции и аналитика",
    });

    foreach (var xmlFile in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
    {
        options.IncludeXmlComments(xmlFile);
    }
});

// Глобальный обработчик ошибок
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.MapControllers();
app.Run();