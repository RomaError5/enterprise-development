namespace FitnessClub.Contracts.Dto;

/// <summary>
/// Специализация (read-модель)
/// </summary>
public class SpecializationDto
{
    /// <summary>
    /// Идентификатор специализации
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название специализации
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
