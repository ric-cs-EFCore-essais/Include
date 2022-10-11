using System.Linq;

using Domain.Repositories.Interfaces.Ports;
using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;

namespace Infra.Repositories.Ports
{
    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IQueryable<Port> GetEntities()
        {
            return dataContext.Ports;
        }
    }
}
