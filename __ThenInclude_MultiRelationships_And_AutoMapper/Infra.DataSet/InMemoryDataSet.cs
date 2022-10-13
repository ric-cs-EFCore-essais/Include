using System.Collections.Generic;

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

        protected override List<TEntity> Load()
        {
            var retour = new List<TEntity>();
            return retour;
        }

        public void Save()
        {
            //
        }

    }
}
