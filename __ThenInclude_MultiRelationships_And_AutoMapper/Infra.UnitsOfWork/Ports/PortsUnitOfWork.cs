using Domain.UnitsOfWork.Interfaces.Ports;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces;

namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWork : AUnitOfWork, IPortsUnitOfWork
    {
        public IVilleRepository VilleRepository { get; init; }
        public IPortRepository PortRepository { get; init; }
        public IAncreRepository AncreRepository { get; init; }
        public IDiplomeRepository DiplomeRepository { get; init; }
        public ICapitaineRepository CapitaineRepository { get; init; }
        public ICapitaineDiplomeRepository CapitaineDiplomeRepository { get; init; }
        public IBateauRepository BateauRepository { get; init; }

        public PortsUnitOfWork(
            IDataContext portsDataContext,
            IVilleRepository villeRepository,
            IPortRepository portRepository,
            IAncreRepository ancreRepository,
            IDiplomeRepository diplomeRepository,
            ICapitaineRepository capitaineRepository,
            ICapitaineDiplomeRepository capitaineDiplomeRepository,
            IBateauRepository bateauRepository
        ) : base(portsDataContext)
        {
            VilleRepository = villeRepository;
            PortRepository = portRepository;
            AncreRepository = ancreRepository;
            DiplomeRepository = diplomeRepository;
            CapitaineRepository = capitaineRepository;
            CapitaineDiplomeRepository = capitaineDiplomeRepository;
            BateauRepository = bateauRepository;
        }
    }
}
