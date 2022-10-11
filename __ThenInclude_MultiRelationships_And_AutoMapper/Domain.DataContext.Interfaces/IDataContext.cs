using System.Linq;

using Domain.Entities.Interfaces;

namespace Domain.DataContext.Interfaces
{
    public interface IDataContext
    {
        void SaveChanges();
        IQueryable<TEntity> Set<TEntity>() where TEntity: IEntity;
    }
}
