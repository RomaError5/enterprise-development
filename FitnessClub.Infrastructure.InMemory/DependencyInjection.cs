using FitnessClub.Domain.Data;
using FitnessClub.Domain.Interfaces;
using FitnessClub.Infrastructure.InMemory.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Infrastructure.InMemory;

/// <summary>
/// Регистрация InMemory-хранилища в DI-контейнере
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавляет seed-данные и репозитории в памяти.
    /// </summary>
    public static IServiceCollection AddInMemoryRepositories(this IServiceCollection services)
    {
        services.AddSingleton<FitnessClubContext>();

        services.AddSingleton<ISpecializationRepository, SpecializationRepository>();
        services.AddSingleton<IClientRepository, ClientRepository>();
        services.AddSingleton<ITrainerRepository, TrainerRepository>();
        services.AddSingleton<ILessonRepository, LessonRepository>();

        return services;
    }
}