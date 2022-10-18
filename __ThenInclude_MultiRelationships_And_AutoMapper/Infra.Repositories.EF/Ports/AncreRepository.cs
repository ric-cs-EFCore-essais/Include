using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class AncreRepository : APortsRepository<Ancre>, IAncreRepository
    {
        public AncreRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<Ancre> GetEntities()
        {
            return dataContext.Ancres;
        }
    }
}
