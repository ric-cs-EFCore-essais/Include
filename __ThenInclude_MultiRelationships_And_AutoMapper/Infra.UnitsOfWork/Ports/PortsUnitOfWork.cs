using Infra.DataContext.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.UnitsOfWork.Interfaces.Ports;

namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWork : AUnitOfWork, IPortsUnitOfWork
    {
        public IVilleRepository VilleRepository { get; init; }
        public IPortRepository PortRepository { get; init; }
        public IAncreRepository AncreRepository { get; }
        public IDiplomeRepository DiplomeRepository { get; }
        public ICapitaineRepository CapitaineRepository { get; }

        public PortsUnitOfWork(
            IDataContext portsDataContext,
            IVilleRepository villeRepository,
            IPortRepository portRepository,
            IAncreRepository ancreRepository,
            IDiplomeRepository diplomeRepository,
            ICapitaineRepository capitaineRepository
        ) : base(portsDataContext)
        {
            VilleRepository = villeRepository;
            PortRepository = portRepository;
            AncreRepository = ancreRepository;
            DiplomeRepository = diplomeRepository;
            CapitaineRepository = capitaineRepository;
        }
    }
}
