using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;
using Domain.Entities.Specifications.Interfaces;

using Domain.Entities.Ports;
using Domain.Entities.Specifications.Ports;
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

        public override Ville Get(int id)
        {
            var retour = IncludingPorts(GetEntities()).SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public override IEnumerable<Ville> GetAll()
        {
            var retour = IncludingPorts(GetEntities()).ToList();
            return retour;
        }

        private IQueryable<Ville> IncludingPorts(IQueryable<Ville> villesQuery)
        {
            var retour = villesQuery.Include(ville => ville.Ports);
            return retour;
        }

        public Ville GetByPort(int portId)
        {
            var retour = IncludingPorts(GetEntities()).SingleOrDefault(ville => ville.Ports.Select(port => port.Id).Contains(portId));
            return retour;
        }

        public IEnumerable<Ville> GetWithNameContaining(string subString)
        {
            subString = subString.ToLower();
            ISpecification<Ville> villeWithNameContainingSpecification = new VilleWithNameContainingSpecification(subString);

            var retours = IncludingPorts(FindAsQueryable(villeWithNameContainingSpecification.FilterExpression));
            
            return retours.ToList();
        }

    }
}
