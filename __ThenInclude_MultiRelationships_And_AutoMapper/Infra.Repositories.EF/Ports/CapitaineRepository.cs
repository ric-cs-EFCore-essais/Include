using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class CapitaineRepository : APortsRepository<Capitaine>, ICapitaineRepository
    {
        public CapitaineRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<Capitaine> GetEntities()
        {
            return dataContext.Capitaines;
        }
    }
}
