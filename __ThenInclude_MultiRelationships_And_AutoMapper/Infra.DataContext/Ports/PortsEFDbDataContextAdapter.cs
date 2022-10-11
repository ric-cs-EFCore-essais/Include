using System;
using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Ports;

using Infra.DataContext.Interfaces.Ports;


namespace Infra.DataContext.Ports
{
    public class PortsEFDbDataContextAdapter : IPortsDataContext
    {
        private readonly PortsEFDbDataContext portsEFDbDataContext;

        public IList<Port> Ports
        {
            get
            {
                return portsEFDbDataContext.Ports.ToList();
            }
        }

        public IList<Ville> Villes
        {
            get
            {
                return portsEFDbDataContext.Villes.ToList();
            }
        }

        public PortsEFDbDataContextAdapter(PortsEFDbDataContext portsEFDbDataContext)
        {
            this.portsEFDbDataContext = portsEFDbDataContext;
        }
        
        public void Dispose()
        {
            Console.WriteLine("portsEFDbDataContext.Dispose !!");
            portsEFDbDataContext.Dispose();
        }

        public void SaveChanges()
        {
            portsEFDbDataContext.SaveChanges();
        }
    }
}
