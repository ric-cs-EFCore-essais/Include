using System;
using System.Collections.Generic;

using Domain.Entities.Ports;

using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

namespace Infra.DataContext.Ports
{
    public class PortsEFDbDataContextAdapter : IPortsDataContext
    {
        private readonly PortsEFDbDataContext portsEFDbDataContext;


        public IDataSet<Port> Ports
        {
            get
            {
            }
        }

        public IDataSet<Ville> Villes
        {
            get
            {
            }
        }


        //public List<Port> Ports
        //{
        //    get
        //    {
        //        return portsEFDbDataContext.Ports as List<Port>;
        //    }
        //}

        //public IList<Ville> Villes
        //{
        //    get
        //    {
        //        return portsEFDbDataContext.Villes as List<Ville>;
        //    }
        //}

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
