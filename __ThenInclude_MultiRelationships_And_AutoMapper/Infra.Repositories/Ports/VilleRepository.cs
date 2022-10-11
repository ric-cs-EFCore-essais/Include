using System.Linq;

using Domain.Repositories.Interfaces.Ports;
using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;

namespace Infra.Repositories.Ports
{
    public class VilleRepository : APortsRepository<Ville>, IVilleRepository
    {
        public VilleRepository(IPortsDataContext dataContext): base(dataContext)
        {
        }

        protected override IQueryable<Ville> GetEntities()
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
