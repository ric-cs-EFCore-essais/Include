using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class AncreRepository : APortsRepository<Ancre>, IAncreRepository
    {
        public AncreRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IDataSet<Ancre> GetDataSet()
        {
            return dataContext.Ancres;
        }
    }
}
