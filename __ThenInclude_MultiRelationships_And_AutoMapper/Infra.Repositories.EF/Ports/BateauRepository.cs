using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;

namespace Infra.Repositories.Ports
{
    public class BateauRepository : APortsRepository<Bateau>, IBateauRepository
    {
        public BateauRepository(PortsDbDataContext dataContext) : base(dataContext)
        {
        }

        protected override DbSet<Bateau> GetEntities()
        {
            return dataContext.Bateaux;
        }
    }
}
