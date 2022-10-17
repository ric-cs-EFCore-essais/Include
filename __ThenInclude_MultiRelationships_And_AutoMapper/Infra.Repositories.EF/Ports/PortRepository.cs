using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<Port> GetEntities()
        {
            return dataContext.Ports;
        }
    }
}
