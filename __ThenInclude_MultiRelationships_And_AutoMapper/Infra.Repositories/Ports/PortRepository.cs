
using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Transverse.Common.DebugTools;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infra.Repositories.Ports
{
    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<Port> GetEntities()
        {
            return dataContext.Ports.Entities;
        }
    }
}
