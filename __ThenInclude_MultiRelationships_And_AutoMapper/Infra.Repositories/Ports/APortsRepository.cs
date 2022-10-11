using Domain.Entities.Interfaces;
using Infra.DataContext.Interfaces.Ports;

namespace Infra.Repositories.Ports
{
    public abstract class APortsRepository<TEntity>: ARepository<TEntity>
        where TEntity : IEntity
    {
        protected IPortsDataContext dataContext;

        protected APortsRepository(IPortsDataContext dataContext) : base()
        {
            this.dataContext = dataContext;
        }

    }
}
