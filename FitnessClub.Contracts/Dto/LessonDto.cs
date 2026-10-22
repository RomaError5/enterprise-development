namespace FitnessClub.Contracts.Dto;

/// <summary>
/// Занятие (read-модель)
/// </summary>
public class LessonDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public ClientDto Client { get; set; } = new();

    /// <summary>
    /// Тренер
    /// </summary>
    public TrainerDto Trainer { get; set; } = new();

    /// <summary>
    /// Дата и время начала
    /// </summary>
    public DateTime DateStart { get; set; }

    /// <summary>
    /// Дата и время окончания
    /// </summary>
    public DateTime? DateEnd { get; set; }

    /// <summary>
    /// Название зала
    /// </summary>
    public string? Hall { get; set; }

    /// <summary>
    /// Пробное занятие или нет
    /// </summary>
    public bool IsTrial { get; set; }
}