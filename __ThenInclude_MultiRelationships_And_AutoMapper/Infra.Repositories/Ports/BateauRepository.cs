using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;


namespace Infra.Repositories.Ports
{
    public class BateauRepository : APortsRepository<Bateau>, IBateauRepository
    {
        public BateauRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<Bateau> GetEntities()
        {
            return dataContext.Bateaux.Entities;
        }
    }
}
