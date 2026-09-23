namespace FitnessClub.Domain.Entities;

/// <summary>
/// Класс специализации (используется для тренера)
/// </summary>
public class Specialization
{
    /// <summary>
    /// Идентифиактор специализации
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название специализации
    /// </summary>
    public string Name { get; set; } = "";
}
