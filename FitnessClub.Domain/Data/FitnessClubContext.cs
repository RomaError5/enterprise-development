using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Enums;

namespace FitnessClub.Domain.Data;

/// <summary>
/// Текстовые данные фитнесс-клуба
/// </summary>
public class FitnessClubContext
{
    /// <summary>
    /// Специализация тренеров
    /// </summary>
    public List<Specialization> Specializations { get; } = [];

    /// <summary>
    /// Тренеры
    /// </summary>
    public List<Trainer> Trainers { get; } = [];

    /// <summary>
    /// Клиенты
    /// </summary>
    public List<Client> Clients { get; } = [];

    /// <summary>
    /// Записи клиентов на занятия
    /// </summary>
    public List<Lesson> Lessons { get; } = [];

    /// <summary>
    /// Инициализация коллекций и их наполнение тестовыми данными
    /// </summary>
    public FitnessClubContext()
    {
        var today = DateTime.Today;

        Specializations = CreateSpecializations();
        Trainers = CreateTrainers(Specializations);
        Clients = CreateClients(today);
        Lessons = CreateLessons(Clients, Trainers, today);
    }

    /// <summary>
    /// Создание списка специализаций тренеров
    /// </summary>
    /// <returns>Список специализаций</returns>
    private static List<Specialization> CreateSpecializations()
    {
        var specializations = new List<Specialization>
        {
            new() { Id = 0, Name = "Йога" },
            new() { Id = 1, Name = "Пилатес" },
            new() { Id = 2, Name = "Бокс" },
            new() { Id = 3, Name = "Плавание" },
            new() { Id = 4, Name = "Кроссфит" },
            new() { Id = 5, Name = "Теннис" },
            new() { Id = 6, Name = "Лёгкая атлетика" },
            new() { Id = 7, Name = "Тяжёлая атлетика" },
            new() { Id = 8, Name = "Фитнес" },
            new() { Id = 9, Name = "Реабилитация" },
        };

        return specializations;
    }

    /// <summary>
    /// Создание списка тренеров
    /// </summary>
    /// <param name="specializations">Список специализаций</param>
    /// <returns>Список тренеров</returns>
    private static List<Trainer> CreateTrainers(List<Specialization> specializations)
    {
        var trainers = new List<Trainer>
        {
            new() { Id = 0, PassportNumber = "4513 104010", FullName = "Иванов Пётр Иванович",       Gender = Gender.Male,   BirthDate = new DateTime(1980, 5, 12),  Specialization = specializations[0], ExperienceYears = 3 },
            new() { Id = 1, PassportNumber = "4532 100002", FullName = "Смирнов Алексей Петрович",   Gender = Gender.Male,   BirthDate = new DateTime(1975, 3, 8),   Specialization = specializations[3], ExperienceYears = 7 },
            new() { Id = 2, PassportNumber = "4521 100003", FullName = "Кузнецова Мария Сергеевна",  Gender = Gender.Female, BirthDate = new DateTime(1988, 7, 21),  Specialization = specializations[0], ExperienceYears = 10 },
            new() { Id = 3, PassportNumber = "4567 102004", FullName = "Соколов Дмитрий Андреевич",  Gender = Gender.Male,   BirthDate = new DateTime(1990, 1, 30),  Specialization = specializations[2], ExperienceYears = 2 },
            new() { Id = 4, PassportNumber = "4589 100008", FullName = "Попова Елена Викторовна",    Gender = Gender.Female, BirthDate = new DateTime(1985, 9, 14),  Specialization = specializations[1], ExperienceYears = 5 },
            new() { Id = 5, PassportNumber = "4512 100006", FullName = "Лебедев Артём Олегович",     Gender = Gender.Male,   BirthDate = new DateTime(1978, 11, 2),  Specialization = specializations[4], ExperienceYears = 12 },
            new() { Id = 6, PassportNumber = "4522 101007", FullName = "Козлов Игорь Владимирович",  Gender = Gender.Male,   BirthDate = new DateTime(1995, 4, 17),  Specialization = specializations[7], ExperienceYears = 1 },
            new() { Id = 7, PassportNumber = "4577 100305", FullName = "Новикова Ольга Дмитриевна",  Gender = Gender.Female, BirthDate = new DateTime(1983, 6, 25),  Specialization = specializations[8], ExperienceYears = 6 },
            new() { Id = 8, PassportNumber = "4553 100009", FullName = "Морозов Павел Игоревич",     Gender = Gender.Male,   BirthDate = new DateTime(1992, 2, 9),   Specialization = specializations[5], ExperienceYears = 4 },
            new() { Id = 9, PassportNumber = "4543 105001", FullName = "Волкова Анна Александровна", Gender = Gender.Female, BirthDate = new DateTime(1986, 4, 26),  Specialization = specializations[9], ExperienceYears = 8 },
        };

        return trainers;
    }

    /// <summary>
    /// Создания списка клиентов
    /// </summary>
    /// <param name="today">Текущая дата</param>
    /// <returns>Список клиентов</returns>
    private static List<Client> CreateClients(DateTime today)
    {
        var clients = new List<Client>
        {
            new() { Id = 0, PassportNumber = "4501 200301", FullName = "Петров Пётр Сергеевич",        Gender = Gender.Male,   BirthDate = new DateTime(1991, 3, 15),  Phone = "+7 911 100-11-11", SubscriptionStart = today.AddMonths(-13), SubscriptionEnd = today.AddMonths(-1) },
            new() { Id = 1, PassportNumber = "4501 204002", FullName = "Орлова Марина Ивановна",       Gender = Gender.Female, BirthDate = new DateTime(1994, 5, 22),  Phone = "+7 911 100-22-22", SubscriptionStart = today.AddMonths(-2),  SubscriptionEnd = today.AddDays(20) },
            new() { Id = 2, PassportNumber = "4541 220003", FullName = "Сидоров Николай Петрович",     Gender = Gender.Male,   BirthDate = new DateTime(1987, 8, 3),   Phone = "+7 911 100-33-33", SubscriptionStart = today.AddMonths(-7),  SubscriptionEnd = today.AddDays(-10) },
            new() { Id = 3, PassportNumber = "4531 200204", FullName = "Белова Ксения Павловна",       Gender = Gender.Female, BirthDate = new DateTime(1996, 10, 11), Phone = "+7 911 100-44-44", SubscriptionStart = today.AddMonths(-1),  SubscriptionEnd = today.AddMonths(2) },
            new() { Id = 4, PassportNumber = "4501 200005", FullName = "Гусев Андрей Юрьевич",         Gender = Gender.Male,   BirthDate = new DateTime(1989, 1, 27),  Phone = "+7 911 100-55-55", SubscriptionStart = today.AddMonths(-6),  SubscriptionEnd = today.AddDays(-5) },
            new() { Id = 5, PassportNumber = "4521 200206", FullName = "Дмитриева Светлана Олеговна",  Gender = Gender.Female, BirthDate = new DateTime(1993, 4, 19),  Phone = "+7 911 100-66-66", SubscriptionStart = today.AddDays(-10),   SubscriptionEnd = today.AddDays(100) },
            new() { Id = 6, PassportNumber = "4511 200307", FullName = "Зайцев Роман Викторович",      Gender = Gender.Male,   BirthDate = new DateTime(1985, 7, 7),   Phone = "+7 911 100-77-77", SubscriptionStart = today.AddMonths(-9),  SubscriptionEnd = today.AddDays(-45) },
            new() { Id = 7, PassportNumber = "4541 205008", FullName = "Киселёва Дарья Максимовна",    Gender = Gender.Female, BirthDate = new DateTime(1998, 2, 14),  Phone = "+7 911 100-88-88", SubscriptionStart = today.AddMonths(-3),  SubscriptionEnd = today.AddDays(14) },
            new() { Id = 8, PassportNumber = "4561 208009", FullName = "Львов Григорий Артёмович",     Gender = Gender.Male,   BirthDate = new DateTime(1990, 11, 29), Phone = "+7 911 100-99-99", SubscriptionStart = today.AddMonths(-12), SubscriptionEnd = today.AddDays(-1) },
            new() { Id = 9, PassportNumber = "4511 200910", FullName = "Миронова Валерия Игоревна",    Gender = Gender.Female, BirthDate = new DateTime(1997, 9, 5),   Phone = "+7 911 100-00-00", SubscriptionStart = today.AddMonths(-4),  SubscriptionEnd = today.AddYears(1) },
        };

        return clients;
    }

    /// <summary>
    /// Создание списка занятий
    /// </summary>
    /// <param name="clients">Список клиентов</param>
    /// <param name="trainers">Список тренеров</param>
    /// <param name="today">Текущая дата</param>
    /// <returns>Список занятий</returns>
    private static List<Lesson> CreateLessons(List<Client> clients, List<Trainer> trainers, DateTime today)
    {
        DateTime S(int day, int hour) => new(today.Year, today.Month, day, hour, 0, 0);

        var hour = TimeSpan.FromHours(1);
        var hourAndHalf = TimeSpan.FromMinutes(90);
        var halfHour = TimeSpan.FromMinutes(30);

        var lessons = new List<Lesson>
        {
            new() { Id = 0, Client = clients[0], Trainer = trainers[2], DateStart = S(5, 10),  Hall = "Зал йоги",        IsTrial = true },
            new() { Id = 1, Client = clients[1], Trainer = trainers[2], DateStart = S(10, 12), Hall = "Зал йоги",        IsTrial = false },
            new() { Id = 2, Client = clients[2], Trainer = trainers[4], DateStart = S(15, 18), Hall = "Зал йоги",        IsTrial = false },
            new() { Id = 3, Client = clients[0], Trainer = trainers[2], DateStart = S(5, 10).AddMonths(-1), Hall = "Зал йоги", IsTrial = false },

            new() { Id = 4, Client = clients[3], Trainer = trainers[0], DateStart = S(3, 9),   Hall = "Основной зал",    IsTrial = false },
            new() { Id = 5, Client = clients[4], Trainer = trainers[0], DateStart = S(8, 11),  Hall = "Основной зал",    IsTrial = false },
            new() { Id = 6, Client = clients[5], Trainer = trainers[0], DateStart = S(12, 16), Hall = "Основной зал",    IsTrial = false },
            new() { Id = 7, Client = clients[6], Trainer = trainers[0], DateStart = S(20, 19), Hall = "Основной зал",    IsTrial = true },
            new() { Id = 8, Client = clients[7], Trainer = trainers[0], DateStart = S(22, 8), DateEnd = S(22, 8) + halfHour,  Hall = "Основной зал",    IsTrial = false },
            new() { Id = 9, Client = clients[8], Trainer = trainers[0], DateStart = S(5, 10).AddMonths(1), Hall = "Основной зал", IsTrial = false },

            new() { Id = 10, Client = clients[9], Trainer = trainers[1], DateStart = S(6, 10),  Hall = "Бассейн",         IsTrial = false },
            new() { Id = 11, Client = clients[0], Trainer = trainers[1], DateStart = S(13, 10), DateEnd = S(13, 10) + hour, Hall = "Бассейн",         IsTrial = true },
            new() { Id = 12, Client = clients[1], Trainer = trainers[1], DateStart = S(21, 10), Hall = "Бассейн",         IsTrial = false },
            new() { Id = 13, Client = clients[2], Trainer = trainers[1], DateStart = S(27, 10), Hall = "Бассейн",         IsTrial = false },

            new() { Id = 14, Client = clients[3], Trainer = trainers[3], DateStart = S(7, 10), DateEnd = S(7, 10) + hourAndHalf,  Hall = "Зал единоборств", IsTrial = false },
            new() { Id = 15, Client = clients[4], Trainer = trainers[3], DateStart = S(14, 10), Hall = "Зал единоборств", IsTrial = true },
        };

        return lessons;
    }
}
