using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;

namespace Infra.DataSet.Interfaces
{
    public interface IDataSet<TEntity>
        where TEntity : IEntity
    {
        IList<TEntity> Entities { get; }
        IQueryable<TEntity> EntitiesAsQueryable { get; }

        void Save(); 
    }
}
