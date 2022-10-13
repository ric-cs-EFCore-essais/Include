using System.Collections.Generic;

using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity, TEntities>
        where TEntity : AEntity
        where TEntities : IEnumerableQueryable<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IRepository<TEntity, TEntities> Add(TEntity entity);
        IRepository<TEntity, TEntities> AddRange(IEnumerable<TEntity> entities);
    }

    public interface IRepository<TEntity>: IRepository<TEntity, IEnumerableQueryable<TEntity>>
        where TEntity : AEntity
    {
    }

}
