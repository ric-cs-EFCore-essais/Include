using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Domain.DataContext.Interfaces;
using Domain.Entities.Interfaces;
using System;

namespace Infra.DataContext.Ports
{
    public class PortsDataContext : AInMemoryDataContext, IDataContext
    {
        private readonly IQueryable<IQueryable> allEntities;

        public PortsDataContext(): base()
        {
            allEntities = new List<IQueryable>().AsQueryable();
        }

        public void SaveChanges()
        {
            //throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> Set<TEntity>() 
            where TEntity : IEntity
        {
            IDictionary<Type, IQueryable<TEntity>> d = new Dictionary<Type, IQueryable<TEntity>>
            {
                {typeof(TEntity), new List<TEntity>(){ }.AsQueryable() }
            };

            IQueryable<TEntity> q;
            d.TryGetValue(typeof(TEntity), out q);

            IQueryable<TEntity> entities = allEntities.FirstOrDefault<TEntity>(entities => entities.GetType()==IQueryable<TEntity>);
            if (entities is null) {
                entities = CreateEntities<TEntity>();
                allEntities.Append(entities);
            }
            return entities;
        }

        private IQueryable<TEntity> CreateEntities<TEntity>()
        {
            var retour = new List<TEntity>().AsQueryable();
            return retour;
        }

    }
}
