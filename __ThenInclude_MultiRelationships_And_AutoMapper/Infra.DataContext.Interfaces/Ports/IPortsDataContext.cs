using System.Collections.Generic;

using Domain.Entities.Ports;
using Infra.DataSet.Interfaces;

namespace Infra.DataContext.Interfaces.Ports
{
    public interface IPortsDataContext: IDataContext
    {
        //IList<Port> Ports { get; }
        //IList<Ville> Villes { get; }


        IDataSet<Port> Ports { get; }
        IDataSet<Ville> Villes { get; }

    }

    public interface IPortsEFDbDataContext : IDataContext
    {
        DbSet<Port> Ports { get; }
        IDataSet<Ville> Villes { get; }

    }
}
