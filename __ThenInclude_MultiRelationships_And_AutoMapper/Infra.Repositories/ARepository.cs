using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;

namespace Infra.Repositories
{
    public abstract class ARepository<TEntity>: IRepository<TEntity>
        where TEntity: IEntity
    {
        protected ARepository()
        {
        }

        protected abstract IList<TEntity> GetEntities();


        public TEntity Get( int id)
        {
            var retour = GetEntities().AsQueryable().SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public IList<TEntity> GetAll()
        {
            var retour = GetEntities();
            return retour;
        }

        public IRepository<TEntity> Add(TEntity entity)
        {
            GetEntities().Add(entity);
            return this;
        }

        public IRepository<TEntity> AddRange(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
            return this;
        }
    }
}
