using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class BateauRepository : APortsRepository<Bateau>, IBateauRepository
    {
        public BateauRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IDataSet<Bateau> GetDataSet()
        {
            return dataContext.Bateaux;
        }
    }
}
