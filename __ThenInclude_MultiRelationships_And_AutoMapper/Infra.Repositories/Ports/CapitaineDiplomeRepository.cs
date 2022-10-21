using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;


namespace Infra.Repositories.Ports
{
    public class CapitaineDiplomeRepository : APortsRepository<CapitaineDiplome>, ICapitaineDiplomeRepository
    {
        public CapitaineDiplomeRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<CapitaineDiplome> GetEntities()
        {
            return dataContext.CapitainesDiplomes.Entities;
        }
    }
}
