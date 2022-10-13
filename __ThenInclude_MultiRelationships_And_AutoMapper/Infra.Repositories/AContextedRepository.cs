using Domain.Repositories.Interfaces;
using Infra.DataContext.Interfaces;

using Domain.Entities;

namespace Infra.Repositories
{
    public abstract class AContextedRepository<TEntity, TDataContext> : ARepository<TEntity, IListEnriched<TEntity>>
        where TEntity : AEntity
        where TDataContext: IDataContext
    {
        protected readonly TDataContext dataContext;

        protected AContextedRepository(TDataContext dataContext = null)
        {
            this.dataContext = dataContext;
        }
    }
}