using Domain.Entities.Interfaces;
using Infra.DataContext.Interfaces.Ports;

namespace Infra.Repositories.Ports
{
    public abstract class APortsRepository<TEntity>: ARepository<TEntity>
        where TEntity : IEntity
    {
        protected IPortsDataContext dataContext;

        //Le DataContext est la grappe de stockage des diverses Entités (Les Port, les Ville, etc...)
        protected APortsRepository(IPortsDataContext dataContext) : base()
        {
            this.dataContext = dataContext;
        }

    }
}
