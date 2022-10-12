using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet;

namespace Infra.DataContext.Ports
{
    public class PortsInMemoryDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsInMemoryDataContext(): base()
        {
            //portsDataSet = new InMemoryDataSet<Port>();
            //villesDataSet = new InMemoryDataSet<Ville>();

            Ports = new InMemoryDataSet<Port>();
            Villes = new InMemoryDataSet<Ville>();
        }
    }
}
