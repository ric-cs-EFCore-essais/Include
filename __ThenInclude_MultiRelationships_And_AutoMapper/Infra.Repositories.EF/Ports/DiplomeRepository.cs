using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class DiplomeRepository : APortsRepository<Diplome>, IDiplomeRepository
    {
        public DiplomeRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<Diplome> GetEntities()
        {
            return dataContext.Diplomes;
        }
    }
}
