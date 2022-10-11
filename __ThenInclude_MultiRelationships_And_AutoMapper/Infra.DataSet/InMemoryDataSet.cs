using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.DataSet
{
    public class InMemoryDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : IEntity
    {
        public InMemoryDataSet(): base()
        {
        }

        protected override IQueryable<TEntity> Load()
        {
            var retour = new List<TEntity>().AsQueryable();
            return retour;
        }

        public void Save()
        {
            //
        }

    }
}
