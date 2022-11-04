using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.DataSet.Interfaces;

using Infra.Common.DiskElements;


namespace Infra.DataSet
{
    public class JsonFileDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : IEntity
    {
        //2 fichiers json par JsonFileDataSet (1 pour les data, l'autre (éventuel) pour les metadata).
        private readonly JsonFile<ListEnriched<TEntity>> jsonFileForData;
        private readonly JsonFile<DataSetMetaData> jsonFileForMetaData;

        private DataSetMetaData metaData;
        public DataSetMetaData MetaData
        {
            get
            {
                return metaData ?? (metaData = LoadMetaData());
            }
        }

        public JsonFileDataSet(string dataJsonFileFullName, string metaDataJsonFileFullName = null) : base()
        {
            this.jsonFileForData = new JsonFile<ListEnriched<TEntity>>(dataJsonFileFullName);

            if (metaDataJsonFileFullName is not null)
            {
                this.jsonFileForMetaData = new JsonFile<DataSetMetaData>(metaDataJsonFileFullName);
            }
        }

        public void Save()
        {
            SaveData();
        }

        protected override IListEnriched<TEntity> Load()
        {
            return LoadData();
        }


        private void SaveData()
        {
            jsonFileForData.Save();
        }
        private void SaveMetaData()
        {
            jsonFileForMetaData?.Save();
        }


        private IListEnriched<TEntity> LoadData()
        {
            return jsonFileForData.Content;
        }

        private DataSetMetaData LoadMetaData()
        {
            return jsonFileForMetaData?.Content;
        }
    }
}
