using System.Collections.Generic;

using Domain.Entities.Interfaces;

namespace Infra.DataSet
{
    public abstract class ADataSet<TEntity>
        where TEntity : IEntity
    {
        private List<TEntity> entities;
        public List<TEntity> Entities
        {
            get
            {
                return entities ?? (entities = Load());
            }
        }

        protected abstract List<TEntity> Load();
    }
}
