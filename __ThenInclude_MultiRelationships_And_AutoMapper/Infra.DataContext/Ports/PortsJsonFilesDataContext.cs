using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataSet;
using Infra.DataContext.Properties.Ports;

namespace Infra.DataContext.Ports
{
    public class PortsJsonFilesDataContext : APortsDataContext, IPortsDataContext
    {
        private readonly JsonFilesDataContext jsonFilesDataContext;

        public PortsJsonFilesDataContext(): base()
        {
            jsonFilesDataContext = new JsonFilesDataContext(GetJsonFilesRootPath());

            Ports = new JsonFileDataSet<Port>(GetJsonDataFileFullName(PortsResources.PortsJsonFileName));
            Villes = new JsonFileDataSet<Ville>(GetJsonDataFileFullName(PortsResources.VillesJsonFileName));
            Ancres = new JsonFileDataSet<Ancre>(GetJsonDataFileFullName(PortsResources.AncresJsonFileName));
            Diplomes = new JsonFileDataSet<Diplome>(GetJsonDataFileFullName(PortsResources.DiplomesJsonFileName));
            Capitaines = new JsonFileDataSet<Capitaine>(GetJsonDataFileFullName(PortsResources.CapitainesJsonFileName));
            CapitainesDiplomes = new JsonFileDataSet<CapitaineDiplome>(GetJsonDataFileFullName(PortsResources.CapitainesDiplomesJsonFileName));
            Bateaux = new JsonFileDataSet<Bateau>(GetJsonDataFileFullName(PortsResources.BateauxJsonFileName));
        }

        private string GetJsonDataFileFullName(string jsonFileName)
        {
            return jsonFilesDataContext.GetJsonDataFileFullName(jsonFileName);
        }

        private string GetJsonMetaDataFileFullName(string jsonFileName)
        {
            return jsonFilesDataContext.GetJsonMetaDataFileFullName(jsonFileName);
        }

        private static string GetJsonFilesRootPath()
        {
            var retour = (Infra.Common.Environment.IsHome()) ? PortsResources.JsonFilesPath_Home : PortsResources.JsonFilesPath_Job;
            return retour;
        }
    }
}
