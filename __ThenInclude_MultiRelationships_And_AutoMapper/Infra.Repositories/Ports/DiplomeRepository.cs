using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class DiplomeRepository : APortsRepository<Diplome>, IDiplomeRepository
    {
        public DiplomeRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IDataSet<Diplome> GetDataSet()
        {
            return dataContext.Diplomes;
        }
    }
}
