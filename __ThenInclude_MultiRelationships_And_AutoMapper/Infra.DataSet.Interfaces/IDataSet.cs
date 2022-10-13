using Domain.Repositories.Interfaces;

using Domain.Entities;

namespace Infra.DataSet.Interfaces
{
    //Chargé de la sauvegarde et du chargement des entités.
    public interface IDataSet<TEntity>
        where TEntity : AEntity
    {
        IListEnriched<TEntity> Entities { get; }

        void Save(); 
    }

}
