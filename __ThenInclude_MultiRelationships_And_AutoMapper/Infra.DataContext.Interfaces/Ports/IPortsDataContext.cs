using System.Linq;

using Domain.Entities.Ports;

namespace Infra.DataContext.Interfaces.Ports
{
    public interface IPortsDataContext: IDataContext
    {
        public IQueryable<Port> Ports { get; }
        public IQueryable<Ville> Villes { get; }
    }
}
