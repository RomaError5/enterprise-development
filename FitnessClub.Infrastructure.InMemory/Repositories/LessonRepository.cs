using FitnessClub.Domain.Data;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory-репозиторий занятий поверх общего seed-контекста
/// </summary>
/// <param name="context">Тестовые данные клуба</param>
public class LessonRepository(FitnessClubContext context) 
    : InMemoryRepository<Lesson>(context.Lessons), ILessonRepository;