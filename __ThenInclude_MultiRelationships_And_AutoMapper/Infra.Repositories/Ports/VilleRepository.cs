using System;
using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Specifications.Interfaces;
using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataSet.Interfaces;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Domain.Entities.Specifications.Ports;

namespace Infra.Repositories.Ports
{
    public class VilleRepository : APortsRepository<Ville>, IVilleRepository
    {
        public VilleRepository(IPortsDataContext dataContext): base(dataContext)
        {
        }

        protected override IDataSet<Ville> GetDataSet()
        {
            return dataContext.Villes;
        }

        public override Ville Get(int id)
        {
            var retour = base.Get(id);
            IncludingPorts(new[] { retour });
            return retour;
        }

        public override IEnumerable<Ville> GetAll()
        {
            var retours = base.GetAll().ToList();
            IncludingPorts(retours);
            return retours;
        }

        private void IncludingPorts(IList<Ville> villes)
        {
            foreach (var ville in villes)
            {
                ville.Ports = GetVillePorts(ville);
            }
        }

        private IList<Port> GetVillePorts(Ville ville)
        {
            var retours = GetPorts().Where(port => port.VilleId == ville.Id).ToList();
            return retours;
        }

        private IListEnriched<Port> GetPorts()
        {
            return dataContext.Ports.Entities;
        }

        public Ville GetByPort(int portId)
        {
            var retour = GetAll().SingleOrDefault(ville => ville.Ports.Select(port => port.Id).Contains(portId));
            return retour;
        }

        public IEnumerable<Ville> GetWithNameContaining(string subString)
        {
            subString = subString.ToLower();
            ISpecification<Ville> villeWithNameContainingSpecification = new VilleWithNameContainingSpecification(subString);

            var retours = Find(villeWithNameContainingSpecification.FilterExpression);
            IncludingPorts(retours as IList<Ville>);
            return retours;
        }
    }
}
