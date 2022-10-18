using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;


namespace Infra.Repositories.Ports
{
    public class DiplomeRepository : APortsRepository<Diplome>, IDiplomeRepository
    {
        public DiplomeRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<Diplome> GetEntities()
        {
            return dataContext.Diplomes.Entities;
        }
    }
}
