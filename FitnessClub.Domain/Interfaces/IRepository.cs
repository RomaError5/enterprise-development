using FitnessClub.Domain.Entities;

namespace FitnessClub.Domain.Interfaces;

public interface IRepository<TEntity, TKey>
{
    public TEntity Create(TEntity entity);
    public TEntity? Read(TKey entityId);
    public IList<TEntity> ReadAll();
    public TEntity Update(TEntity entity);
    public bool Delete(TKey entityId);
}
