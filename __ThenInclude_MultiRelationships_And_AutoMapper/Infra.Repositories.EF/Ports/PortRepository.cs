using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query; //Pour IIncludableQueryable

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class PortAvecVille : Port
    {
        public Ville Ville { get; }
    }

    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<Port> GetEntities()
        {
            return dataContext.Ports;
        }

        public override Port Get(int id)
        {
            var retour = IncludingBateaux(GetEntities()).SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public override IEnumerable<Port> GetAll()
        {
            var retour = IncludingBateaux(GetEntities()).ToList();
            return retour;
        }

        private IQueryable<Port> IncludingBateaux(IQueryable<Port> portsQuery)
        {
            var retour = portsQuery
                            .Include(port => port.Ville)
                            .Include(port => port.Bateaux)
                                .ThenInclude(bateau => bateau.Capitaine)
                                    .ThenInclude(capitaine => capitaine.CapitainesDiplomes) //ATTENTION : CapitainesDiplomes doit être une property (au sens : property C#)
                                        //.ThenInclude(capitaineDiplome => capitaineDiplome.DiplomeId) //<<<<INTERDIT, il doit s'agir d'une instance
                                            .ThenInclude(capitaineDiplome => capitaineDiplome.Diplome)

                            .Include(port => port.Bateaux)
                                .ThenInclude(bateau => bateau.Ancre)
                            ;
            return retour;
        }
    }
}
