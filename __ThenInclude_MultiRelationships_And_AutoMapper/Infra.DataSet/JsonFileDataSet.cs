using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataSet.Interfaces;

using Infra.Common.DiskElements;


namespace Infra.DataSet
{
    public class JsonFileDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : IEntity
    {
        //2 fichiers json par JsonFileDataSet (1 pour les data, l'autre pour les metadata).
        private readonly JsonFile<ListEnriched<TEntity>> jsonFileForData;
        private readonly JsonFile<DataSetMetaData> jsonFileForMetaData;

        public JsonFileDataSet(string dataJsonFileFullName, string metaDataJsonFileFullName) : base()
        {
            this.jsonFileForData = new JsonFile<ListEnriched<TEntity>>(dataJsonFileFullName);

            this.jsonFileForMetaData = new JsonFile<DataSetMetaData>(metaDataJsonFileFullName);
        }

        public void SaveData()
        {
            jsonFileForData.Save();
        }

        protected override  IListEnriched<TEntity> LoadData()
        {
            return jsonFileForData.Content;
        }

        public void SaveMetaData()
        {
            jsonFileForMetaData.Save();
        }

        protected override IDataSetMetaData LoadMetaData()
        {
            return jsonFileForMetaData.Content;
        }
    }
}
