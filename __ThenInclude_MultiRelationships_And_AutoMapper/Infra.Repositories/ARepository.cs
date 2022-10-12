using System.Collections.Generic;
using System.Linq;

using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public abstract class ARepository<TEntity> : ARepository0<TEntity, IList<TEntity>>
        where TEntity : IEntity
    {

    }

    public abstract class ARepository2<TEntity> : ARepository0<TEntity, DbSet<TEntity>>
        where TEntity : IEntity
    {

    }

    public abstract class ARepository0<TEntity, TEntities>  //: IRepository<TEntity>
        where TEntity: IEntity
        where TEntities : IList<TEntity>
    {
        protected ARepository0()
        {
        }

        protected abstract TEntities GetEntities();


        public TEntity Get( int id)
        {
            var retour = GetEntities().AsQueryable().SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public TEntities GetAll()
        {
            var retour = GetEntities();
            return retour;
        }

        //public IRepository<TEntity> Add(TEntity entity)
        public ARepository0<TEntity, TEntities> Add(TEntity entity)
        {
            GetEntities().Add(entity);
            return this;
        }

        public IRepository<TEntity> AddRange(IList<TEntity> entities)
        {
            GetEntities().AsQueryable().Concat(entities);
            foreach (var entity in entities)
            {
                Add(entity);
            }
            return this;
        }
    }
}
