using FitnessClub.Domain.Enums;

namespace FitnessClub.Contracts.Dto;

/// <summary>
/// Тренер (read-модель)
/// </summary>
public class TrainerDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;

    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Специализация
    /// </summary>
    public SpecializationDto Specialization { get; set; } = new();

    /// <summary>
    /// Стаж работы (лет)
    /// </summary>
    public int ExperienceYears { get; set; }
}