using System.Linq;

using Domain.Entities.Ports;

using Infra.DataContext.Interfaces.Ports;


namespace Infra.DataContext.Ports
{
    public class PortsEFDbDataContextAdapter : IPortsDataContext
    {
        private readonly PortsEFDbDataContext portsEFDbDataContext;

        public IQueryable<Port> Ports
        {
            get
            {
                return portsEFDbDataContext.Ports;
            }
        }

        public IQueryable<Ville> Villes
        {
            get
            {
                return portsEFDbDataContext.Villes;
            }
        }

        public PortsEFDbDataContextAdapter(PortsEFDbDataContext portsEFDbDataContext)
        {
            this.portsEFDbDataContext = portsEFDbDataContext;
        }
        
        public void Dispose()
        {
            portsEFDbDataContext.Dispose();
        }

        public void SaveChanges()
        {
            portsEFDbDataContext.SaveChanges();
        }
    }
}
