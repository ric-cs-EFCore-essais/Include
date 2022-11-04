using Infra.DataSet.Interfaces;
using Domain.Entities.Interfaces;

using Transverse.Common.Strings;

using Infra.Common.DiskElements;

using Infra.DataSet;

namespace Infra.DataContext
{
    public class JsonFilesDataContext  //(DataContext pour json files : 1 file par type d'entité)
    {
        private readonly string jsonFilesRootPath;

        public JsonFilesDataContext(string jsonFilesRootPath)
        {
            this.jsonFilesRootPath = jsonFilesRootPath;
        }

        public IDataSet<TEntity> GetJsonFileDataSet<TEntity>(string jsonFileName)
            where TEntity : IEntity
        {
            var retour = new JsonFileDataSet<TEntity>(
                GetJsonDataFileFullName(jsonFileName),
                GetJsonMetaDataFileFullName(jsonFileName)
            );
            return retour;
        }

        private string GetJsonDataFileFullName(string jsonFileName)
        {
            var jsonFileFullNamePrefix = GetJsonFileFullNamePrefix(jsonFileName);
            var retour = $"{jsonFileFullNamePrefix}Data.json";
            return retour;
        }

        private string GetJsonMetaDataFileFullName(string jsonFileName)
        {
            var jsonFileFullNamePrefix = GetJsonFileFullNamePrefix(jsonFileName);
            var retour = $"{jsonFileFullNamePrefix}MetaData.json";
            return retour;
        }

        private string GetJsonFileFullNamePrefix(string jsonFileName)
        {
            var jsonFilesRootPath_ = URLsHelper.BackSlash(jsonFilesRootPath, false).EndsWith_(false, "/");

            var retour = $"{jsonFilesRootPath_}/{jsonFileName}/{jsonFileName}_";
            return retour;
        }
    }
}
