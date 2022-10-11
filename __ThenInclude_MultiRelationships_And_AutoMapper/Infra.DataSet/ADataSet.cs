using System.Linq;

using Domain.Entities.Interfaces;

namespace Infra.DataSet
{
    public abstract class ADataSet<TEntity>
        where TEntity : IEntity
    {
        private IQueryable<TEntity> entities;
        public IQueryable<TEntity> Entities
        {
            get
            {
                return entities ?? (entities = Load());
            }
        }

        protected abstract IQueryable<TEntity> Load();
    }
}
