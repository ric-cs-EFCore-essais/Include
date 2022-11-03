using System;
using System.IO;
using System.Text.Json;

using Domain.Entities.Interfaces;
using Domain.Repositories.Interfaces;
using Infra.Common.DiskElements;
using Infra.DataSet.Interfaces;


namespace Infra.DataSet.MetaData
{
    public class JsonFileDataSetMetaData
    {
        private readonly string jsonFile;

        public JsonFileDataSetMetaData(string jsonFile)
        {
            if (string.IsNullOrWhiteSpace(jsonFile))
            {
                throw new ArgumentException($"'{nameof(jsonFile)}' ne peut pas avoir une valeur null ou être un espace blanc.", nameof(jsonFile));
            }

            this.jsonFile = jsonFile;
        }

        public void Save()
        {
            var jsonFileContent = JsonSerializer.Serialize<DataSetMetaData>(Entities);
            FilesHelper.SetFileContent(jsonFile, jsonFileContent);
        }

        protected DataSetMetaData Load()
        {
            DataSetMetaData retour;
            var jsonFileContent = GetFileContent();
            if (!string.IsNullOrWhiteSpace(jsonFileContent))
            {
                retour = JsonSerializer.Deserialize<DataSetMetaData>(jsonFileContent);

            }
            else
            {
                retour = new DataSetMetaData();
            }

            return retour;
        }

        private string GetFileContent()
        {
            string retour = null;

            try
            {
                retour = File.ReadAllText(jsonFile);
            }
            catch (Exception) {}

            return retour;
        }
    }
}
