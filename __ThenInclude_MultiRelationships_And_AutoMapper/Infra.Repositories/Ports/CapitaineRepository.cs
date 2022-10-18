using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;


namespace Infra.Repositories.Ports
{
    public class CapitaineRepository : APortsRepository<Capitaine>, ICapitaineRepository
    {
        public CapitaineRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<Capitaine> GetEntities()
        {
            return dataContext.Capitaines.Entities;
        }
    }
}
