using FitnessClub.Domain.Entities;
using FitnessClub.Domain.Interfaces;

namespace FitnessClub.Infrastructure.InMemory.Repositories;

/// <summary>
/// Реализация репозитория поверх коллекции
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly List<TEntity> _items;
    private int _nextId;

    /// <summary>
    /// Создаёт репозиторий
    /// </summary>
    /// <param name="seed">Начальные данные</param>
    public InMemoryRepository(IEnumerable<TEntity>? seed = null)
    {
        _items = seed?.ToList() ?? [];
        _nextId = _items.Count == 0 ? 0 : _items.Max(e => e.Id) + 1;
    }

    /// <summary>
    /// Добавляет сущность
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns></returns>
    public Task<TEntity> Create(TEntity entity)
    {
        entity.Id = _nextId++;
        _items.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Возвращает копию списка всех сущностей
    /// </summary>
    /// <returns></returns>
    public Task<IReadOnlyList<TEntity>> ReadAll() => Task.FromResult<IReadOnlyList<TEntity>>([.. _items]);

    /// <summary>
    /// Возвращает сущность по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор</param>
    /// <returns></returns>
    public Task<TEntity?> Read(long entityId) => Task.FromResult(_items.FirstOrDefault(e => e.Id == entityId));

    /// <summary>
    /// Заменяет сущность
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns></returns>
    public Task<bool> Update(TEntity entity)
    {
        var index = _items.FindIndex(e => e.Id == entity.Id);
        if (index < 0) return Task.FromResult(false);

        _items[index] = entity;
        return Task.FromResult(true);
    }

    /// <summary>
    /// Удаляет сущность
    /// </summary>
    /// <param name="entityId">Идентификатор</param>
    /// <returns></returns>
    public Task<bool> Delete(long entityId)
    {
        var entity = _items.FirstOrDefault(e => e.Id == entityId);
        if (entity is null) return Task.FromResult(false);

        _items.Remove(entity);
        return Task.FromResult(true);
    }
}
