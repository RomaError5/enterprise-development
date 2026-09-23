namespace FitnessClub.Domain.Entities;

/// <summary>
/// Класс тренера
/// </summary>
public class Trainer : Person
{
    /// <summary>
    /// Специализация тренера
    /// </summary>
    public Specialization Specialization { get; set; } = new();

    /// <summary>
    /// Стаж работы
    /// </summary>
    public int ExperienceYears { get; set; }
}
