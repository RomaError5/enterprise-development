using FitnessClub.Domain.Data;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory-репозиторий тренеров поверх общего seed-контекста
/// </summary>
/// <param name="context">Тестовые данные клуба</param>
public class TrainerRepository(FitnessClubContext context) : InMemoryRepository<Trainer>(context.Trainers), ITrainerRepository
{
}