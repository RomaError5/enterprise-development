namespace FitnessClub.Domain.Entities;

/// <summary>
/// Запись клиента на занятия 
/// </summary>
public class Lesson
{
    /// <summary>
    /// Клиент
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Тренер
    /// </summary>
    public required Trainer Trainer { get; set; }
    public DateTime Date { get; set; }

    /// <summary>
    /// Дата и время начала занятия
    /// </summary>
    public required DateTime DateStart { get; set; }

    /// <summary>
    /// Дата и время окончания занятия
    /// </summary>
    public DateTime? DateEnd { get; set; }

    /// <summary>
    /// Название зала, в котором проходит занятие
    /// </summary>
    public string Hall { get; set; } = "";

    /// <summary>
    /// Пробное занятие или нет
    /// </summary>
    public bool IsTrial { get; set; }
}
