using FitnessClub.Domain.Enums;

namespace FitnessClub.Contracts.Dto;

/// <summary>
/// Клиент (read-модель)
/// </summary>
public class ClientDto
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
    /// Телефон
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Дата начала абонемента
    /// </summary>
    public DateTime SubscriptionStart { get; set; }

    /// <summary>
    /// Дата окончания абонемента
    /// </summary>
    public DateTime SubscriptionEnd { get; set; }
}