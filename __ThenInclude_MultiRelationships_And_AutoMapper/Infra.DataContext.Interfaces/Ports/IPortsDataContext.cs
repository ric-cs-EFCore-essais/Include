using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.DataContext.Interfaces.Ports
{
    public interface IPortsDataContext: IDataContext
    {
        IDataSet<Port> Ports { get; }
        IDataSet<Ville> Villes { get; }
    }
}
