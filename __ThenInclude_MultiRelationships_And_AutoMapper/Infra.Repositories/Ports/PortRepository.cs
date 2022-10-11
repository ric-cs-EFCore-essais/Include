using Domain.Entities.Ports;
using Domain.Repositories.Interfaces.Ports;
using Domain.DataContext.Interfaces;

namespace Infra.Repositories
{
    public class PortRepository : ARepository<Port>, IPortRepository
    {
        public PortRepository(IDataContext dataContext): base(dataContext)
        {

        }
    }
}
