using Domain.Repositories.Interfaces;
using Domain.Entities;


namespace Infra.Repositories
{
    public abstract class AContextedRepository<TEntity, TContext> : ARepository<TEntity, IEnumerableQueryable<TEntity>>
        where TEntity : AEntity
    {
        protected readonly TContext dataContext;

        protected AContextedRepository(TContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}