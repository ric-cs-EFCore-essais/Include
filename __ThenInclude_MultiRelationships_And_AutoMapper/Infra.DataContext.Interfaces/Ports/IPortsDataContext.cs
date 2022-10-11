using System.Collections.Generic;

using Domain.Entities.Ports;

namespace Infra.DataContext.Interfaces.Ports
{
    public interface IPortsDataContext: IDataContext
    {
        public IList<Port> Ports { get; }
        public IList<Ville> Villes { get; }
    }
}
