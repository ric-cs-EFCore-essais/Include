using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class CapitaineRepository : APortsRepository<Capitaine>, ICapitaineRepository
    {
        public CapitaineRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IDataSet<Capitaine> GetDataSet()
        {
            return dataContext.Capitaines;
        }
    }
}
