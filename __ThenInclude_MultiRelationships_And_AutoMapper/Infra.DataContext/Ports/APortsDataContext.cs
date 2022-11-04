using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.DataContext.Ports
{
    public abstract class APortsDataContext : ADataContext
    {
        public IDataSet<Port> Ports { get; protected set; }
        public IDataSet<Ville> Villes { get; protected set; }
        public IDataSet<Ancre> Ancres { get; protected set; }
        public IDataSet<Diplome> Diplomes { get; protected set; }
        public IDataSet<Capitaine> Capitaines { get; protected set; }
        public IDataSet<CapitaineDiplome> CapitainesDiplomes { get; protected set; }
        public IDataSet<Bateau> Bateaux { get; protected set; }

        protected APortsDataContext() : base()
        {
        }

        public void Save()
        {
            Ports?.Save();
            Villes?.Save();
            Ancres?.Save();
            Diplomes?.Save();
            Capitaines?.Save();
            CapitainesDiplomes?.Save();
            Bateaux?.Save();
        }

        public void Dispose()
        {
        }
    }
}
