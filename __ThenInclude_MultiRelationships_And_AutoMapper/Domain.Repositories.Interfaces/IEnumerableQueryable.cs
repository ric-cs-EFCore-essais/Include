using System.Collections.Generic;
using System.Linq;

using Domain.Entities;


namespace Domain.Repositories.Interfaces
{
    //Pour bénéficier en plus sur ce type IQueryable, d'un accès aux méthodes Add, AddRange, ...
    // sans avoir à convertir(copie), notre IQueryable en IEnumerable (via ToList() typiquement).
    public partial interface IEnumerableQueryable<TEntity> : IQueryable<TEntity>
        where TEntity : AEntity
    {
        IQueryable<TEntity> AsQueryable();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
    }
}
