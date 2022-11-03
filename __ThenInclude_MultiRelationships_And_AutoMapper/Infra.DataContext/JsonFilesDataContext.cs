using Transverse.Common.Strings;

using Infra.Common.DiskElements;

namespace Infra.DataContext
{
    public class JsonFilesDataContext
    {
        private readonly string jsonFilesRootPath;

        public JsonFilesDataContext(string jsonFilesRootPath)
        {
            this.jsonFilesRootPath = jsonFilesRootPath;
        }

        public string GetJsonDataFileFullName(string jsonFileName)
        {
            var jsonFileFullNamePrefix = GetJsonFileFullNamePrefix(jsonFileName);
            var retour = $"{jsonFileFullNamePrefix}Data.json";
            return retour;
        }

        public string GetJsonMetaDataFileFullName(string jsonFileName)
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
