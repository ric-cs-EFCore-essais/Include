namespace Infra.DataSet.Interfaces
{
    //Chargé de la sauvegarde et du chargement des metadata d'une entité.
    public interface IDataSetMetaData
    {
        int CurrentAutoIncrementId { get; set; }
    }

}
