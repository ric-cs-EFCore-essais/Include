using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataContext.Ports;
using Infra.Repositories.Ports;

namespace Infra.UnitsOfWork.Ports
{
    public class PortsUnitOfWorkFactory
    {
        private PortsJsonFilesDataContext portsDataContext;

        private IVilleRepository villeRepository;
        private IPortRepository portRepository;

        public PortsUnitOfWork GetInstance()
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
            var retour = portsDataContext ?? (portsDataContext = new PortsJsonFilesDataContext());
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
