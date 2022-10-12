using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Ports;
using Infra.DataSet.Interfaces;

namespace Infra.DataContext.Ports
{
    public abstract class APortsDataContext
    {

        public IDataSet<Port> Ports { get; protected set; }
        public IDataSet<Ville> Villes { get; protected set; }

        //protected IDataSet<Port> portsDataSet;
        //public IList<Port> Ports 
        //{ 
        //    get 
        //    {
        //        return portsDataSet.Entities;
        //    }
        //}

        //protected IDataSet<Ville> villesDataSet;
        //public IList<Ville> Villes
        //{
        //    get
        //    {
        //        return villesDataSet.Entities;
        //    }
        //}

        protected APortsDataContext()
        {
        }

        public void SaveChanges()
        {
            //portsDataSet?.Save();
            //villesDataSet?.Save();
            Ports?.Save();
            Villes?.Save();
        }

        public void Dispose()
        {
        }
    }
}
