using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Domain.Entities.Interfaces;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Func<TEntity, bool> filter);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filterExpression);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
    }
}