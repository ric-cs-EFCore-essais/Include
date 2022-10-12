using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataContext.Properties;
using Infra.DataSet;

namespace Infra.DataContext.Ports
{
    public class PortsJsonFilesDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsJsonFilesDataContext(): base()
        {
            //portsDataSet = new JsonFileDataSet<Port>(Resources.PortsJsonFile);
            //villesDataSet = new JsonFileDataSet<Ville>(Resources.VillesJsonFile);

            Ports = new JsonFileDataSet<Port>(Resources.PortsJsonFile);
            Villes = new JsonFileDataSet<Ville>(Resources.VillesJsonFile);

        }
    }
}
