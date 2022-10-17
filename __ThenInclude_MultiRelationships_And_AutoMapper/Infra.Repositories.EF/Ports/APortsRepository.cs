using Microsoft.EntityFrameworkCore;

using Domain.Entities;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public abstract class APortsRepository<TEntity>: AContextedRepository<TEntity, DbSet<TEntity>, PortsDbDataContext>
        where TEntity : AEntity
    {
        protected APortsRepository(PortsDbDataContext dataContext): base(dataContext)
        {

        }
    }
}
