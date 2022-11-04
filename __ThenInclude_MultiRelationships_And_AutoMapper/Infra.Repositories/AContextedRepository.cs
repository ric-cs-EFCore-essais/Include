using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataContext.Interfaces;

namespace Infra.Repositories
{
    public abstract class AContextedRepository<TEntity, TEntities, TDataContext> : ARepository<TEntity, TEntities>
        where TEntity : IEntity
        where TEntities : IListEnriched<TEntity>
        where TDataContext: IDataContext
    {
        protected readonly TDataContext dataContext;

        protected AContextedRepository(TDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public override void Add(TEntity entity)
        {
            base.Add(entity);
            dataContext.
            dataContext.Save();
        }
    }
}