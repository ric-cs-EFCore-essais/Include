using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;

namespace Infra.DataSet.Interfaces
{
    //Chargé de la sauvegarde et du chargement des entités de type TEntity.
    public interface IDataSet<TEntity>
        where TEntity : IEntity
    {
        IListEnriched<TEntity> Entities { get; }
        void SaveData(); 

        IDataSetMetaData MetaData { get; }
        void SaveMetaData();
    }

}
