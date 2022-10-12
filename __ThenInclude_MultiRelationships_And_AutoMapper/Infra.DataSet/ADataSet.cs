using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;

namespace Infra.DataSet
{
    public abstract class ADataSet<TEntity>
        where TEntity : IEntity
    {
        private IList<TEntity> entities;
        public IList<TEntity> Entities
        {
            get
            {
                return entities ?? (entities = Load());
            }
        }

        public IQueryable<TEntity> EntitiesAsQueryable
        {
            get
            {
                return Entities.AsQueryable<TEntity>();
            }
        }

        protected abstract IList<TEntity> Load();
    }
}
