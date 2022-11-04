using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.DataSet
{
    public class InMemoryDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : IEntity
    {
        public InMemoryDataSet(): base()
        {
        }

        protected override IListEnriched<TEntity> LoadData()
        {
            var retour = new ListEnriched<TEntity>();
            return retour;
        }

        public void SaveData()
        {
            //
        }

        protected override IDataSetMetaData LoadMetaData()
        {
            var retour = new DataSetMetaData();
            return retour;
        }

        public void SaveMetaData()
        {
            //
        }
    }
}
