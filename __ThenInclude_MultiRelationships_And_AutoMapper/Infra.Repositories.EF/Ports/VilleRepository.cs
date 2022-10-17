using System.Linq;

using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class VilleRepository : APortsRepository<Ville>, IVilleRepository
    {
        public VilleRepository(PortsDbDataContext dataContext): base(dataContext)
        {
        }

        protected override DbSet<Ville> GetEntities()
        {
            return dataContext.Villes;
        }

        public Ville GetByPort(int portId)
        {
            var retour = GetEntities().SingleOrDefault(ville => ville.Ports.Select(port => port.Id).Contains(portId));
            return retour;
        }

    }
}
