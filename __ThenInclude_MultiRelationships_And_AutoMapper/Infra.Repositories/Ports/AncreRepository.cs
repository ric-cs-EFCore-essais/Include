using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;


namespace Infra.Repositories.Ports
{
    public class AncreRepository : APortsRepository<Ancre>, IAncreRepository
    {
        public AncreRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<Ancre> GetEntities()
        {
            return dataContext.Ancres.Entities;
        }
    }
}
