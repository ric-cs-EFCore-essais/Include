using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

using Domain.Entities.Interfaces;
using Infra.DataSet.Interfaces;

namespace Infra.DataSet
{
    public class JsonFileDataSet<TEntity>: ADataSet<TEntity>, IDataSet<TEntity>
        where TEntity : IEntity
    {
        private readonly string jsonFile;

        public JsonFileDataSet(string jsonFile): base()
        {
            if (string.IsNullOrWhiteSpace(jsonFile))
            {
                throw new ArgumentException($"'{nameof(jsonFile)}' ne peut pas avoir une valeur null ou être un espace blanc.", nameof(jsonFile));
            }

            this.jsonFile = jsonFile;
        }

        public void Save()
        {
            var jsonFileContent = JsonSerializer.Serialize<IQueryable<TEntity>>(Entities);
            File.WriteAllText(jsonFile, jsonFileContent);
        }

        protected override IQueryable<TEntity> Load()
        {
            IQueryable<TEntity> retour;
            var jsonFileContent = GetFileContent();
            if (!string.IsNullOrWhiteSpace(jsonFileContent))
            {
                retour = JsonSerializer.Deserialize<IQueryable<TEntity>>(jsonFileContent);

            }
            else
            {
                retour = new List<TEntity>().AsQueryable();
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
            catch (FileNotFoundException) {}

            return retour;
        }
    }
}
