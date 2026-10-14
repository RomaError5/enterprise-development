namespace FitnessClub.Domain.Entities;

/// <summary>
/// Базовый контракт сущности
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public int Id { get; set; }
}
