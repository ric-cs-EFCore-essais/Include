using System;
using System.Collections.Generic;

using Domain.Entities.Interfaces;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> filter);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
    }
}