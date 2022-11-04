using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;

namespace Domain.Repositories.Interfaces
{
    //Pour avoir un type équivalent à IList mais enrichi.
    // On complète avec des signatures de méthodes (pourtant déjà implémentées dans la classe List).
    //  (En effet, par ex. : AddRange existe dans List, mais pas dans IList !!)
    public interface IListEnriched<TEntity>: IList<TEntity> //, IQueryable<TEntity>
        where TEntity : IEntity
    {
        void AddRange(IEnumerable<TEntity> entities);
    }

    public class ListEnriched<TEntity> : List<TEntity>, IListEnriched<TEntity>
        where TEntity : IEntity
    {
    }
}
