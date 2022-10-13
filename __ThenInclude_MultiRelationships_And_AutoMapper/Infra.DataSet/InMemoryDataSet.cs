using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.DataSet
{
    public class InMemoryDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : AEntity
    {
        public InMemoryDataSet(): base()
        {
        }

        protected override IEnumerableQueryable<TEntity> Load()
        {
            var retour = new QueryableList<TEntity>();
            return retour;
        }

        public void Save()
        {
            //
        }

    }
}
