using FitnessClub.Domain.Entities;

namespace FitnessClub.Domain.Interfaces;

/// <summary>
/// Репозиторий клиентов
/// </summary>
public interface IClientRepository : IRepository<Client>
{
    Task<object?> Read(int? clientId);
}