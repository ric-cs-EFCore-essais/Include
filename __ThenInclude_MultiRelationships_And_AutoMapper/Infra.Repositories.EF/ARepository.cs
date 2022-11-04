using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Transverse.Common.DebugTools;

using Domain.Repositories.Interfaces;

using Domain.Entities;

namespace Infra.Repositories
{
    //>>> ATTENTION : un ToList() crée une COPIE de la dite liste !!!

    public abstract class ARepository<TEntity, TEntities> : IRepository<TEntity>
        where TEntity : AEntity
        where TEntities : DbSet<TEntity>
    {
        protected abstract TEntities GetEntities();
        protected abstract void SetEntityId(TEntity entity);

        public virtual TEntity Get(int id)
        {
            var retour = GetEntities().SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        //public IEnumerable<TEntity> Find(Func<TEntity, bool> filter)
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filterExpression)
        {
            var retour = FindAsQueryable(filterExpression).ToList();
            return retour;
        }

        protected IQueryable<TEntity> FindAsQueryable(Expression<Func<TEntity, bool>> filterExpression)
        {
            var retour = GetEntities().Where(filterExpression);
            return retour;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var retour = GetEntities().ToList();
            return retour;
        }

        public void Add(TEntity entity)
        {
            AddRange(new List<TEntity> { entity });
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            CheckIfEntitiesCanBeAdded(entities);
            foreach (var entity in entities)
            {
                GetEntities().Add(entity);
                SetEntityId(entity);
            }
        }

        private static void CheckIfEntitiesCanBeAdded(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                CheckIfEntityCanBeAdded(entity);
            }
        }

        private static void CheckIfEntityCanBeAdded(TEntity entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception($"entity.Id must be 0, for an insertion operation : {Debug.GetSerializedData(entity)}");
            }
        }
    }
}
