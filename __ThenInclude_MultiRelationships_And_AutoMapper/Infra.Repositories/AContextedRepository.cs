using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataContext.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.Repositories
{
    public abstract class AContextedRepository<TEntity, TDataContext> : ARepository<TEntity, IListEnriched<TEntity>> //, IRepository<TEntity>
        where TEntity : IEntity
        where TDataContext: IDataContext
    {
        protected readonly TDataContext dataContext;

        protected AContextedRepository(TDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        protected abstract IDataSet<TEntity> GetDataSet();

        protected override IListEnriched<TEntity> GetEntities()
        {
            return GetDataSet().Entities;
        }

        protected IDataSetMetaData GetMetaData()
        {
            return GetDataSet().MetaData;
        }

        protected override void SetEntityId(TEntity entity)
        {
            entity.Id = ++GetMetaData().CurrentAutoIncrementId;
            GetDataSet().SaveMetaData();
        }
    }
}