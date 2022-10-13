using System.Collections.Generic;

using Domain.Entities.Interfaces;

namespace Infra.DataSet.Interfaces
{
    //Chargé de la sauvegarde et du chargement des entités.
    public interface IDataSet<TEntity>
        where TEntity : IEntity
    {
        List<TEntity> Entities { get; }

        void Save(); 
    }
}
