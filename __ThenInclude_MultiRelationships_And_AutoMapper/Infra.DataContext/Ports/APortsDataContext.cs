using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.DataContext.Ports
{
    public abstract class APortsDataContext
    {
        public IDataSet<Port> Ports { get; protected set; }
        public IDataSet<Ville> Villes { get; protected set; }
        public IDataSet<Ancre> Ancres { get; protected set; }
        public IDataSet<Diplome> Diplomes { get; protected set; }
        public IDataSet<Capitaine> Capitaines { get; protected set; }

        protected APortsDataContext()
        {
        }

        public void Save()
        {
            Ports?.Save();
            Villes?.Save();
            Ancres?.Save();
            Diplomes?.Save();
            Capitaines?.Save();
        }

        public void Dispose()
        {
        }
    }
}
