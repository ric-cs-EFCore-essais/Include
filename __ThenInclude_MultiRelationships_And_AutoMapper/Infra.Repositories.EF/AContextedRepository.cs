using Microsoft.EntityFrameworkCore;

using Domain.Entities;

namespace Infra.Repositories
{
    public abstract class AContextedRepository<TEntity, TEntities, TDataContext> : ARepository<TEntity, TEntities>
        where TEntity : AEntity
        where TEntities : DbSet<TEntity>
        where TDataContext: DbContext
    {
        protected readonly TDataContext dataContext;

        protected AContextedRepository(TDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}