namespace FitnessClub.Contracts.Dto;

/// <summary>
/// Результат проверки доступности зала
/// </summary>
public class HallAvailabilityDto
{
    /// <summary>
    /// Название зала
    /// </summary>
    public string Hall { get; set; } = string.Empty;

    /// <summary>
    /// Проверяемый момент времени
    /// </summary>
    public DateTime CheckedTime { get; set; }

    /// <summary>
    /// Доступен ли зал
    /// </summary>
    public bool IsAvailable { get; set; }
}