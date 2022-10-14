using Domain.Repositories.Interfaces.Ports;
using Infra.UnitsOfWork.Interfaces;
using Infra.DataContext.Interfaces.Ports;


namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWork : AUnitOfWork, IUnitOfWork
    {
        public IVilleRepository VilleRepository { get; init; }
        public IPortRepository PortRepository { get; init; }

        public PortsUnitOfWork(
            IPortsDataContext portsDataContext,
            IVilleRepository villeRepository,
            IPortRepository portRepository
        ): base(portsDataContext)
        {
            this.VilleRepository = villeRepository;
            this.PortRepository = portRepository;
        }
    }
}
