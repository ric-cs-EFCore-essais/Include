using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.DataContext.Ports
{
    public abstract class APortsDataContext
    {
        public IDataSet<Port> Ports { get; protected set; }
        public IDataSet<Ville> Villes { get; protected set; }

        protected APortsDataContext()
        {
        }

        public void Save()
        {
            Ports?.Save();
            Villes?.Save();
        }

        public void Dispose()
        {
        }
    }
}
