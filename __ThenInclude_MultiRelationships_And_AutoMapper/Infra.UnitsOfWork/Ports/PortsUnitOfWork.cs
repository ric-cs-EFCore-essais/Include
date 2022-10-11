using Domain.Repositories.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces;
using Domain.DataContext.Interfaces;

using Infra.Repositories;

namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWork : AUnitOfWork, IUnitOfWork
    {
        public IVilleRepository VilleRepository { get; private set; }
        public IPortRepository PortRepository { get; private set; }

        public PortsUnitOfWork(IDataContext dataContext) : base(dataContext)
        {
            PortRepository = new PortRepository(dataContext);
            VilleRepository = new VilleRepository(dataContext);
        }
    }
}
