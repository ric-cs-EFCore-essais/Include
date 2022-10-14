using Domain.Entities;

using Infra.DataContext.Interfaces.Ports;

namespace Infra.Repositories.Ports
{
    public abstract class APortsRepository<TEntity>: AContextedRepository<TEntity, IPortsDataContext>
        where TEntity : AEntity
    {
        protected APortsRepository(IPortsDataContext dataContext): base(dataContext)
        {

        }
    }
}
