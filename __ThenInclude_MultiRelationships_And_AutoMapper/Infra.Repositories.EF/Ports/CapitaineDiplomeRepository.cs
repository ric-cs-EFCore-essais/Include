using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class CapitaineDiplomeRepository : APortsRepository<CapitaineDiplome>, ICapitaineDiplomeRepository
    {
        public CapitaineDiplomeRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<CapitaineDiplome> GetEntities()
        {
            return dataContext.CapitainesDiplomes;
        }
    }
}
