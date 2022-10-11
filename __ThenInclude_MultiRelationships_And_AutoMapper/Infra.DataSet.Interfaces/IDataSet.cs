using System.Linq;

using Domain.Entities.Interfaces;

namespace Infra.DataSet.Interfaces
{
    public interface IDataSet<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TEntity> Entities { get; }

        void Save();
    }
}
