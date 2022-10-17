using Microsoft.EntityFrameworkCore;

using Infra.Common.DataAccess.Interfaces;  //Issu d'un Nuget perso. mis dans ./../../../../____Common/zzMyLocalPublishedPackages/

using Infra.DataContext.EF.Interfaces;

namespace Infra.DataContext.EF.Ports
{
    public class PortsDbDataContextFactory : ADbDataContextFactory<PortsDbDataContext>, IDbDataContextFactory<PortsDbDataContext>
    {
        private static PortsDbDataContextFactory factorySingleton;

        public static PortsDbDataContextFactory GetSingleton(IDBServerAccessConfiguration dbServerAccessConfiguration)
        {
            var retour = factorySingleton ?? (factorySingleton = new PortsDbDataContextFactory(dbServerAccessConfiguration));
            return retour;
        }

        public PortsDbDataContextFactory(IDBServerAccessConfiguration dbServerAccessConfiguration): base(dbServerAccessConfiguration)
        {
        }

        protected override PortsDbDataContext CreateDbDataContext(DbContextOptions<PortsDbDataContext> options)
        {
            var retour = new PortsDbDataContext(options);
            return retour;
        }

    }
}