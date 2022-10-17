using Domain.Repositories.Interfaces.Ports;
using Infra.UnitsOfWork.Interfaces.Ports;

using Infra.DataContext.EF.Interfaces;

using Infra.UnitsOfWork.Ports;
using Infra.DataContext.EF.Ports;
using Infra.Repositories.Ports;

namespace Infra.UnitsOfWork.EF.Factories.Ports
{
    public class PortsUnitOfWorkFactory : IPortsUnitOfWorkFactory
    {
        private PortsDbDataContext portsDataContext;
        private readonly IDbDataContextFactory<PortsDbDataContext> dbDataContextFactory;

        private IVilleRepository villeRepository;
        private IPortRepository portRepository;

        public PortsUnitOfWorkFactory(IDbDataContextFactory<PortsDbDataContext> dbDataContextFactory)
        {
            this.dbDataContextFactory = dbDataContextFactory;
        }

        public IPortsUnitOfWork GetInstance()
        {
            var retour = new PortsUnitOfWork(
                GetDataContext(),
                GetVilleRepository(),
                GetPortRepository()
            );
            return retour;
        }

        private PortsDbDataContext GetDataContext()
        {
            var retour = portsDataContext ?? (portsDataContext = CreateDataContext());
            return retour;
        }

        private PortsDbDataContext CreateDataContext()
        {
            var retour = dbDataContextFactory.GetSqlServerInstance();
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
