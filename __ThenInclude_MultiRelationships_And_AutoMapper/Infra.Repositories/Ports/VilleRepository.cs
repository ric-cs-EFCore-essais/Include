using System.Linq;

using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class VilleRepository : APortsRepository<Ville>, IVilleRepository
    {
        public VilleRepository(IPortsDataContext dataContext): base(dataContext)
        {
        }

        protected override IEnumerableQueryable<Ville> GetEntities()
        {
            return dataContext.Villes as IEnumerableQueryable<Ville>;
        }

        public Ville GetByPort(int portId)
        {
            var retour = GetEntities().SingleOrDefault(ville => ville.Ports.Select(port => port.Id).Contains(portId));
            return retour;
        }

    }
}
