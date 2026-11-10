# Разработка корпоративных приложений — лабораторная работа №2

## «Сервер — REST API»
В рамках второй лабораторной работы для предметной области реализовано серверное приложение с использованием ASP.NET Core Web API.

Сервер предоставляет REST API для выполнения CRUD-операций над сущностями первой лабораторной работы, операций получения связанных данных и аналитических запросов.

Данные хранятся в памяти в виде коллекций.

Вариант: 53

---

## Предметная область
Проект моделирует работу фитнесс-клуба.

### Основные сущности
| Класс | Назначение |
|---|---|
| `Person` | Базовый класс с персональными данными, общими для клиента и тренера: номер паспорта, ФИО, пол (`Gender` — перечисление), дата рождения |
| `Client` | Клиент фитнес-клуба: телефон, дата начала и дата окончания абонемента |
| `Trainer` | Тренер фитнес-клуба: специализация (сущность-справочник `Specialization`), стаж работы |
| `Lesson` | Запись клиента на занятие: клиент, тренер, дата и время начала (окончание может проставляться позднее), название зала, признак пробного посещения |

## Архитектура решения

| Проект | Назначение |
|---|---|
| `FitnessClub.Api` | ASP.NET Core Web API: контроллеры, HTTP-маршруты и конфигурация приложения |
| `FitnessClub.Application` | Сервисы, бизнес-логика, обработка CRUD-операций и аналитических запросов |
| `FitnessClub.Contracts` | DTO для передачи данных и интерфейсы сервисов |
| `FitnessClub.Domain` | Сущности предметной области и интерфейсы репозиториев, генератор тестовых данных |
| `FitnessClub.Infrastructure.InMemory` | Хранение данных в памяти, реализации репозиториев |
| `FitnessClub.Tests` | Модульные тесты предметной области и сервисных запросов |

## REST API

Для основных сущностей реализован полный CRUD.

### Clients

```text
POST   /api/clients
GET    /api/clients
GET    /api/clients/{id}
PUT    /api/clients/{id}
DELETE /api/clients/{id}
```

### Lessons

```text
POST   /api/lessons
GET    /api/lessons
GET    /api/lessons/{id}
PUT    /api/lessons/{id}
DELETE /api/lessons/{id}
```

### Specializations

```text
POST   /api/specializations
GET    /api/specializations
GET    /api/specializations/{id}
PUT    /api/specializations/{id}
DELETE /api/specializations/{id}
```

### Trainers

```text
POST   /api/trainers
GET    /api/trainers
GET    /api/trainers/{id}
PUT    /api/trainers/{id}
DELETE /api/trainers/{id}
```

### Analytics

```text
GET /api/analytics/trainers/experienced
GET /api/analytics/clients/expired-subscription
GET /api/analytics/halls/availability
GET /api/analytics/halls/lessons
GET /api/analytics/trainers/top
```

Для POST и PUT используются `ClientEditDto`, `LessonEditDto`,
`SpecializationEditDto`, `UpsertTrainingSessionDto` без поля `id`.
Идентификатор создаётся в репозитории; при обновлении он берётся из маршрута. Название специализации тренера заполняется сервером только в ответе.

* POST возвращает `201 Created` и DTO.
* PUT возвращает `200 OK` и обновлённый DTO.
* DELETE возвращает `204 No Content`.
* Несуществующая запись — `404 Not Found`.
* Ошибки валидации — `400 Bad Request` в формате `ValidationProblemDetails`.
* Непредвиденные ошибки — `500 Internal Server Error` без внутренних деталей.

## Unit-тесты
* Тренеры, стаж работы которых не менее 5 лет.
* Клиенты с просроченным абонементом, упорядоченные по ФИО.
* Проверка доступности зала для записи в данный момент.
* Занятия за текущий месяц в выбранном зале.
* Топ-5 наиболее популярных тренеров.

## Запуск

```bash
dotnet run --project src/FitnessClub.Api
```

Сервер доступен на `http://localhost:5297/swagger/index.html` или `https://localhost:7075/swagger/index.html`

### Запуск тестов
```bash
dotnet test
```

Тесты также выполняются автоматически в GitHub Actions при каждом push и pull request.
