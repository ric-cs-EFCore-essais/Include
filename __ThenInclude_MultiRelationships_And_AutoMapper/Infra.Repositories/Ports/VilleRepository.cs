using System.Linq;

using Domain.Entities.Ports;
using Domain.Repositories.Interfaces.Ports;
using Domain.DataContext.Interfaces;

namespace Infra.Repositories
{
    public class VilleRepository : ARepository<Ville>, IVilleRepository
    {
        public VilleRepository(IDataContext dataContext): base(dataContext)
        {

        }

        public Ville FindByPort(int portId)
        {
            var retour = GetEntities().SingleOrDefault(ville => ville.Ports.Select(port => port.Id).Contains(portId));
            return retour;
        }

    }
}
