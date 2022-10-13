
using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Transverse.Common.DebugTools;
using System;
using System.Collections.Generic;

namespace Infra.Repositories.Ports
{
    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override List<Port> GetEntities()
        {
            Console.WriteLine("1");
            Debug.ShowData(dataContext.Ports.Entities);
            Debug.ShowData(dataContext.Ports.Entities);
            Debug.ShowData(dataContext.Ports.Entities as IEnumerableQueryable<Port>);
            Console.WriteLine("2");
            return dataContext.Ports.Entities;
        }
    }
}
