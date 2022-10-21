using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.DataContext.Interfaces.Ports
{
    public interface IPortsDataContext: IDataContext
    {
        IDataSet<Port> Ports { get; }
        IDataSet<Ville> Villes { get; }
        IDataSet<Ancre> Ancres { get; }
        IDataSet<Diplome> Diplomes { get; }
        IDataSet<Capitaine> Capitaines { get; }
        IDataSet<CapitaineDiplome> CapitainesDiplomes { get; }
        IDataSet<Bateau> Bateaux { get; }
    }
}
