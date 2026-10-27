using FitnessClub.Domain.Entities;

namespace FitnessClub.Domain.Interfaces;

/// <summary>
/// Репозиторий клиентов
/// </summary>
public interface IClientRepository : IRepository<Client>
{
    public Task<object?> Read(int? clientId);
}