using Infra.DataContext.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.UnitsOfWork.Interfaces.Ports;

namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWork : AUnitOfWork, IPortsUnitOfWork
    {
        public IVilleRepository VilleRepository { get; init; }
        public IPortRepository PortRepository { get; init; }

        public PortsUnitOfWork(
            IDataContext portsDataContext,
            IVilleRepository villeRepository,
            IPortRepository portRepository
        ) : base(portsDataContext)
        {
            this.VilleRepository = villeRepository;
            this.PortRepository = portRepository;
        }
    }
}
