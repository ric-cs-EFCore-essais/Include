using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Entities.Interfaces;

namespace Domain.Repositories.Interfaces
{
    //Pour avoir un type équivalent à IList mais enrichi.
    // On complète avec des signatures de méthodes (pourtant déjà implémentées dans la classe List).
    //  (En effet, par ex. : AddRange existe dans List, mais pas dans IList !!)
    public partial interface IListEnriched<TEntity>: IList<TEntity> //, IQueryable<TEntity>
        where TEntity : AEntity
    {
        void AddRange(IEnumerable<TEntity> entities);
    }

    public class ListEnriched<TEntity> : List<TEntity>, IListEnriched<TEntity>
        where TEntity : AEntity
    {
    }
}
