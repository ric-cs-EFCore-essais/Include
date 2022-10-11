using System.Collections.Generic;

using Domain.Entities.Interfaces;

namespace Infra.DataSet.Interfaces
{
    public interface IDataSet<TEntity>
        where TEntity : IEntity
    {
        IList<TEntity> Entities { get; }

        void Save();
    }
}
