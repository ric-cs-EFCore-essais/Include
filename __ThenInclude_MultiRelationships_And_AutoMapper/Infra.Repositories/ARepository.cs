using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Transverse.Common.DebugTools;

using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;

namespace Infra.Repositories
{
    //>>> ATTENTION : un ToList() crée une COPIE de la dite liste !!!

    public abstract class ARepository<TEntity, TEntities> : IRepository<TEntity>
        where TEntity : IEntity
        where TEntities : IListEnriched<TEntity>
    {
        protected abstract TEntities GetEntities();

        public virtual TEntity Get(int id)
        {
            var retour = GetEntities().SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filterExpression)
        {
            var retour = GetEntities().AsQueryable().Where(filterExpression).ToList();
            return retour;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var retour = GetEntities().ToList();
            return retour;
        }

        public virtual void Add(TEntity entity)
        {
            if (entity.Id == 0) 
            { 
                GetEntities().Add(entity);
            } 
            else
            {
                throw new Exception($"entity.Id must be 0, for an insertion operation : {Debug.GetSerializedData(entity)}");
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                Add(entity);
            }
        }

        public void Remove(TEntity entity) //By Value (ici une adresse donc)
        {
            GetEntities().Remove(entity);
        }
    }
}
