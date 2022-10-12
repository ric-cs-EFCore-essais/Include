using Domain.Repositories.Interfaces.Ports;

using Infra.Repositories.Ports;
using Infra.UnitsOfWork.Interfaces;
using Infra.DataContext.Interfaces.Ports;
using Domain.Entities.Ports;
using System.Linq;

namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWork : AUnitOfWork, IUnitOfWork
    {
        public IVilleRepository VilleRepository { get; private set; }
        public IPortRepository PortRepository { get; private set; }

        public PortsUnitOfWork(IPortsDataContext dataContext) : base(dataContext)
        {
            PortRepository = new PortRepository(dataContext);
            VilleRepository = new VilleRepository(dataContext);
        }
    }
}
