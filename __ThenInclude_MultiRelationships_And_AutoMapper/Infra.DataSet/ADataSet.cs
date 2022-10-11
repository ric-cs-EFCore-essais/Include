using System.Collections.Generic;

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

        protected abstract IList<TEntity> Load();
    }
}
