using System.Collections.Generic;

using Domain.Entities.Interfaces;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity Find(int id);

        IList<TEntity> GetAll();
    }
    
}
