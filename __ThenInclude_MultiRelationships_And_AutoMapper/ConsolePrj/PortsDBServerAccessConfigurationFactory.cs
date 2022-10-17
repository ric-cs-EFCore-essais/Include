using Infra.Common.DataAccess.Interfaces;
using Infra.Common.DataAccess;

using Transverse.Common.DebugTools;

namespace ConsolePrj
{
    public class PortsDBServerAccessConfigurationFactory
    {
        private IDBServerAccessConfiguration dbServerAccessConfiguration;

        public IDBServerAccessConfiguration GetSingleton()
        {
            var retour = dbServerAccessConfiguration ?? (dbServerAccessConfiguration = CreateDBServerAccessConfiguration());
            return retour;
        }

        private IDBServerAccessConfiguration CreateDBServerAccessConfiguration()
        {
            var retour = new DBServerAccessConfiguration()
            {
                DatabaseName = "Essais_EF_ThenInclude_MultiRelationships"
            };
            Debug.ShowData(retour);
            return retour;
        }

    }
}
