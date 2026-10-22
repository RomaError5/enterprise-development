using System.Text.Json.Serialization;
using FitnessClub.Api.Infrastructure;
using FitnessClub.Application;
using FitnessClub.Infrastructure.InMemory;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Хранилище (InMemory): seed-данные и репозитории.
// На третьей лабе эта строка заменяется на регистрацию MsSqlServer-реализаций
builder.Services.AddInMemoryRepositories();

// Бизнес-логика: CRUD- и аналитические сервисы
builder.Services.AddApplicationServices();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        // Enum'ы (например, Gender) приходят и уходят строками: "Male", "Female"
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

// Глобальная обработка ошибок: всё логируется, клиенту — ProblemDetails без деталей реализации
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