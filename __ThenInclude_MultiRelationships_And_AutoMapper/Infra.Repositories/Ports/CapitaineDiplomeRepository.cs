using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class CapitaineDiplomeRepository : APortsRepository<CapitaineDiplome>, ICapitaineDiplomeRepository
    {
        public CapitaineDiplomeRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IDataSet<CapitaineDiplome> GetDataSet()
        {
            return dataContext.CapitainesDiplomes;
        }
    }
}
