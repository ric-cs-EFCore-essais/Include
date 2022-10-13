using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;

namespace Infra.DataSet
{
    public abstract class ADataSet<TEntity>
        where TEntity : AEntity
    {
        private IEnumerableQueryable<TEntity> entities;
        public IEnumerableQueryable<TEntity> Entities
        {
            get
            {
                return entities ?? (entities = Load());
            }
        }

        protected abstract IEnumerableQueryable<TEntity> Load();
    }
}
