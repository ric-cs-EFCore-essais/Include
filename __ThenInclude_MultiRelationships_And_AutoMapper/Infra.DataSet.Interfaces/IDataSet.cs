using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;

namespace Infra.DataSet.Interfaces
{
    //Chargé de la sauvegarde et du chargement des entités.
    public interface IDataSet<TEntity>
        where TEntity : AEntity
    {
        IEnumerableQueryable<TEntity> Entities { get; }

        void Save(); 
    }

}
