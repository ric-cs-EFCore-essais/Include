using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Extensions
{
    public static class EntitiesListExtension
    {
        public static List<TEntity> WithIds<TEntity>(this List<TEntity> list, int initialId = 1)
            where TEntity : IEntity
        {
            int entityId = initialId;

            foreach (IEntity entity in list)
            {
                if (entity.Id <=0)
                {
                    entity.Id = entityId++;
                }
            }

            return (list);
        }
    }
}
