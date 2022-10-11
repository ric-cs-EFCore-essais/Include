using System.Linq;

using Domain.Entities.Ports;
using Infra.DataSet.Interfaces;

namespace Infra.DataContext.Ports
{
    public abstract class APortsDataContext
    {
        protected IDataSet<Port> portsDataSet;
        public IQueryable<Port> Ports 
        { 
            get 
            {
                return portsDataSet.Entities;
            }
        }

        protected IDataSet<Ville> villesDataSet;
        public IQueryable<Ville> Villes
        {
            get
            {
                return villesDataSet.Entities;
            }
        }

        protected APortsDataContext()
        {
        }

        public void SaveChanges()
        {
            portsDataSet?.Save();
            villesDataSet?.Save();
        }

        public void Dispose()
        {
        }
    }
}
