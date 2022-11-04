using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.DataSet
{
    public abstract class ADataSet<TEntity>
        where TEntity : IEntity
    {
        private IListEnriched<TEntity> entities;
        public IListEnriched<TEntity> Entities
        {
            get
            {
                return entities ?? (entities = LoadData());
            }
        }

        protected abstract IListEnriched<TEntity> LoadData();



        private IDataSetMetaData metaData;
        public IDataSetMetaData MetaData
        {
            get
            {
                return metaData ?? (metaData = LoadMetaData());
            }
        }

        protected abstract IDataSetMetaData LoadMetaData();
    }
}
