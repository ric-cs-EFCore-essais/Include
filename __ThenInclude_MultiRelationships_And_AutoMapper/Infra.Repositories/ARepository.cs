using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;
using Domain.DataContext.Interfaces;

namespace Infra.Repositories
{
    public abstract class ARepository<TEntity>
        where TEntity: IEntity
    {
        private readonly IDataContext dataContext;

        protected ARepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        protected IQueryable<TEntity> GetEntities()
        {
            var retour = dataContext.Set<TEntity>();
            return retour;
        }

        public TEntity Find(int id)
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
