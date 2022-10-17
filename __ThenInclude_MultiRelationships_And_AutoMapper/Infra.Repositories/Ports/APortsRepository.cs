using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataContext.Interfaces.Ports;

namespace Infra.Repositories.Ports
{
    public abstract class APortsRepository<TEntity>: AContextedRepository<TEntity, IListEnriched<TEntity>, IPortsDataContext>
        where TEntity : IEntity
    {
        protected APortsRepository(IPortsDataContext dataContext): base(dataContext)
        {

        }
    }
}
