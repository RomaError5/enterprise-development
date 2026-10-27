using FitnessClub.Domain.Data;
using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// InMemory-репозиторий клиентов поверх общего seed-контекста
/// </summary>
/// <param name="context">Тестовые данные клуба</param>
public class ClientRepository(FitnessClubContext context) 
    : InMemoryRepository<Client>(context.Clients), IClientRepository;