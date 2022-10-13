using System.Collections.Generic;

using Domain.Entities.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.DataSet
{
    public class DbDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : IEntity
    {
        public DbDataSet(): base()
        {
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        protected override List<TEntity> Load()
        {
            var retour = new List<TEntity>();
            return retour;
        }
    }
}
