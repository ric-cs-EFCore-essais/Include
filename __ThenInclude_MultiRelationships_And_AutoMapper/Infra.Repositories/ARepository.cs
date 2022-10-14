using System.Collections.Generic;
using System.Linq;

using Domain.Repositories.Interfaces;
using Domain.Entities;
using System;

namespace Infra.Repositories
{
    
    //>>> ATTENTION : un ToList() crée une COPIE de la dite liste !!!

    public abstract class ARepository<TEntity, TEntities> : IRepository<TEntity, TEntities>
        where TEntity : AEntity
        where TEntities : IListEnriched<TEntity>
    {
        protected abstract TEntities GetEntities();

        public TEntity Get(int id)
        {
            var retour = GetEntities().SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> filter)
        {
            var retour = GetEntities().Where(entity => filter(entity));
            return retour;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var retour = GetEntities().ToList();
            return retour;
        }

        public IRepository<TEntity, TEntities> Add(TEntity entity)
        {
            GetEntities().Add(entity);
            return this;
        }

        public IRepository<TEntity, TEntities> AddRange(IEnumerable<TEntity> entities)
        {
            GetEntities().AddRange(entities);
            return this;
        }
    }
}
