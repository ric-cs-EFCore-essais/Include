using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataSet;

namespace Infra.DataContext.Ports
{
    public class PortsInMemoryDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsInMemoryDataContext(): base()
        {
            Ports = new InMemoryDataSet<Port>();
            Villes = new InMemoryDataSet<Ville>();
            Ancres = new InMemoryDataSet<Ancre>();
            Diplomes = new InMemoryDataSet<Diplome>();
            Capitaines = new InMemoryDataSet<Capitaine>();
        }
    }
}
