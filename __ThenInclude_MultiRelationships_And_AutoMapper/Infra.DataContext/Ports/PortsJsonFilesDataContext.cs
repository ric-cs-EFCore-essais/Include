using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataSet;
using Infra.DataContext.Properties;

namespace Infra.DataContext.Ports
{
    public class PortsJsonFilesDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsJsonFilesDataContext(): base()
        {
            Ports = new JsonFileDataSet<Port>(Resources.PortsJsonFile);
            Villes = new JsonFileDataSet<Ville>(Resources.VillesJsonFile);
        }
    }
}
