using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;

namespace Infra.Repositories
{
    public abstract class ARepository<TEntity>
        where TEntity: IEntity
    {
        protected ARepository()
        {
        }

        protected abstract IQueryable<TEntity> GetEntities();


        public TEntity Get( int id)
        {
            var retour = GetEntities().SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public IList<TEntity> GetAll()
        {
            var retour = GetEntities().ToList();
            return retour;
        }
    }
}
