using Infra.DataContext.Interfaces.Ports;
using Domain.Repositories.Interfaces.Ports;
using Infra.UnitsOfWork.Interfaces.Ports;

using Infra.DataContext.Ports;
using Infra.Repositories.Ports;
using Infra.UnitsOfWork.Ports;

namespace Infra.UnitsOfWork.Factories.Ports
{
    public class PortsUnitOfWorkFactory : IPortsUnitOfWorkFactory
    {
        private IPortsDataContext portsDataContext;

        private IVilleRepository villeRepository;
        private IPortRepository portRepository;

        public IPortsUnitOfWork GetInstance()
        {
            var retour = new PortsUnitOfWork(
                GetDataContext(),
                GetVilleRepository(),
                GetPortRepository()
            );
            return retour;
        }

        private IPortsDataContext GetDataContext()
        {
            var retour = portsDataContext ?? (portsDataContext = CreateDataContext());
            return retour;
        }

        private IPortsDataContext CreateDataContext()
        {
            var retour = new PortsJsonFilesDataContext();
            return retour;
        }

        private IVilleRepository GetVilleRepository()
        {
            var retour = villeRepository ?? (villeRepository = new VilleRepository(GetDataContext()));
            return retour;
        }

        private IPortRepository GetPortRepository()
        {
            var retour = portRepository ?? (portRepository = new PortRepository(GetDataContext()));
            return retour;
        }
    }
}
