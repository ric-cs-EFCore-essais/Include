using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Entities.Interfaces;

namespace Domain.Repositories.Interfaces
{
    //Pour bénéficier en plus sur ce type IQueryable, d'un accès aux méthodes Add, AddRange, ...
    // sans avoir à convertir(copie), notre IQueryable en IEnumerable (via ToList() typiquement).
    public partial interface IEnumerableQueryable<TEntity> : IList<TEntity> //, IQueryable<TEntity>
        where TEntity : AEntity
    {
        void AddRange(IEnumerable<TEntity> entities);
    }

    public class QueryableList<TEntity> : List<TEntity>, IEnumerableQueryable<TEntity>
        where TEntity : AEntity
    {
    }
}
