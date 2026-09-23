using FitnessClub.Domain.Data;

namespace FitnessClub.Tests;

/// <summary>
/// Юнит-тесты
/// </summary>
public class FitnessClubTests
{
    /// <summary>
    /// Контекст с текстовыми данными клуба
    /// </summary>
    private readonly FitnessClubContext _db = new();

    /// <summary>
    /// Проверка: вывод информации о всех тренерах, стаж работы которых не менее 5 лет
    /// </summary>
    [Fact]
    public void TrainersWithExperienceAtLeast5Years_ReturnsSortedByFullName()
    {
        string[] expected =
        [
            "Волкова Анна Александровна",
            "Кузнецова Мария Сергеевна",
            "Лебедев Артём Олегович",
            "Новикова Ольга Дмитриевна",
            "Попова Елена Викторовна",
            "Смирнов Алексей Петрович",
        ];

        var trainers = _db.Trainers
            .Where(t => t.ExperienceYears >= 5)
            .OrderBy(t => t.FullName)
            .ToList();

        Assert.Equal(6, trainers.Count);
        Assert.Equal(expected, trainers.Select(t => t.FullName));
    }

    /// <summary>
    /// Проверка: вывод информации о клиентах с просроченным абонементом, упорядоченный по ФИО
    /// </summary>
    [Fact]
    public void ClientsWithExpiredSubscription_ReturnsOrderedByName()
    {
        string[] expected =
        [
            "Гусев Андрей Юрьевич",
            "Зайцев Роман Викторович",
            "Львов Григорий Артёмович",
            "Петров Пётр Сергеевич",
            "Сидоров Николай Петрович",
        ];

        var clients = _db.Clients
            .Where(c => c.SubscriptionEnd < DateTime.Today)
            .OrderBy(c => c.FullName)
            .ToList();

        Assert.Equal(5, clients.Count);
        Assert.Equal(expected, clients.Select(c => c.FullName));
    }

    /// <summary>
    /// Проверка: проверка того, является ли зал доступным для записи в данный момент
    /// </summary>
    [Theory]
    [InlineData(7, 9, 59, true)]
    [InlineData(7, 10, 0, false)]
    [InlineData(7, 11, 29, false)]
    [InlineData(7, 11, 30, true)]
    [InlineData(7, 12, 0, true)]
    public void HallAvailability_MatchesSchedule(int day, int hour, int minute, bool expected)
    {
        bool IsHallAvailable(string hall, DateTime time) =>
        !_db.Lessons.Any(l =>
            l.Hall == hall &&
            l.DateStart <= time &&
            time < l.DateEnd);

        var today = DateTime.Today;
        var time = new DateTime(today.Year, today.Month, day, hour, minute, 0);

        Assert.Equal(expected, IsHallAvailable("Зал единоборств", time));
    }

    /// <summary>
    /// Проверка: вывод информации о занятиях за текущий месяц, проводимых в этом зале
    /// </summary>
    [Fact]
    public void LessonsOfCurrentMonthInSelectedHall_ReturnsSortedByDate()
    {
        string[] expected =
        [
            "Кузнецова Мария Сергеевна",
            "Кузнецова Мария Сергеевна",
            "Попова Елена Викторовна",
        ];

        var lessons = _db.Lessons
            .Where(l => l.Hall == "Зал йоги" &&
                        l.DateStart.Year == DateTime.Today.Year &&
                        l.DateStart.Month == DateTime.Today.Month)
            .OrderBy(l => l.DateStart)
            .ToList();

        Assert.Equal(3, lessons.Count);
        Assert.Equal(expected, lessons.Select(l => l.Trainer.FullName));
    }

    /// <summary>
    /// Проверка: вывод топ 5 наиболее популярных тренеров
    /// </summary>
    [Fact]
    public void Top5PopularTrainers_ReturnsOrderedByLessonsCount()
    {
        string[] expected =
        [
            "Иванов Пётр Иванович",
            "Смирнов Алексей Петрович",
            "Кузнецова Мария Сергеевна",
            "Соколов Дмитрий Андреевич",
            "Попова Елена Викторовна",
        ];

        var top = _db.Lessons
            .GroupBy(l => l.Trainer)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key.FullName)
            .ToList();

        Assert.Equal(expected, top);
    }
}