using System;
using System.Collections.Generic;

using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity, TEntities>
        where TEntity : AEntity
        where TEntities : IListEnriched<TEntity>
    {
        TEntity Get(int id);

        IEnumerable<TEntity> Find(Func<TEntity, bool> filter);
        IEnumerable<TEntity> GetAll();
        IRepository<TEntity, TEntities> Add(TEntity entity);
        IRepository<TEntity, TEntities> AddRange(IEnumerable<TEntity> entities);
    }

    public interface IRepository<TEntity>: IRepository<TEntity, IListEnriched<TEntity>>
        where TEntity : AEntity
    {
    }

}
