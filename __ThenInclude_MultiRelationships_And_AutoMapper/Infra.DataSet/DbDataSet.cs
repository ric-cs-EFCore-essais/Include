using System.Collections.Generic;
using System.Linq;

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

        protected override IQueryable<TEntity> Load()
        {
            var retour = new List<TEntity>().AsQueryable();
            return retour;
        }
    }
}
