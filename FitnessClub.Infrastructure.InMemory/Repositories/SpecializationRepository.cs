using FitnessClub.Domain.Data;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory-репозиторий специализаций поверх общего seed-контекста
/// </summary>
/// <param name="context">Тестовые данные клуба</param>
public class SpecializationRepository(FitnessClubContext context) : InMemoryRepository<Specialization>(context.Specializations), ISpecializationRepository
{
}