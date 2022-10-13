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
        public IVilleRepository VilleRepository { get; init; }
        public IPortRepository PortRepository { get; init; }

        public PortsUnitOfWork(
            IVilleRepository villeRepository,
            IPortRepository portRepository
        ): base(null)
        {
            this.VilleRepository = villeRepository;
            this.PortRepository = portRepository;
        }
    }
}
