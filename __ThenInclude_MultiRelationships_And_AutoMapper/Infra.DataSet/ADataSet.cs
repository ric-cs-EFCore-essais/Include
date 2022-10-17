using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;

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
                return entities ?? (entities = Load());
            }
        }

        protected abstract IListEnriched<TEntity> Load();
    }
}
