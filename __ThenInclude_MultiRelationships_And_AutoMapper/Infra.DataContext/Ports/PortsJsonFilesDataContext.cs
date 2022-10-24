using System.IO;

using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataSet;
using Infra.DataContext.Properties.Ports;

namespace Infra.DataContext.Ports
{
    public class PortsJsonFilesDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsJsonFilesDataContext(): base()
        {
            Ports = new JsonFileDataSet<Port>(GetJsonFileFullName(PortsResources.PortsJsonFile));
            Villes = new JsonFileDataSet<Ville>(GetJsonFileFullName(PortsResources.VillesJsonFile));
            Ancres = new JsonFileDataSet<Ancre>(GetJsonFileFullName(PortsResources.AncresJsonFile));
            Diplomes = new JsonFileDataSet<Diplome>(GetJsonFileFullName(PortsResources.DiplomesJsonFile));
            Capitaines = new JsonFileDataSet<Capitaine>(GetJsonFileFullName(PortsResources.CapitainesJsonFile));
            CapitainesDiplomes = new JsonFileDataSet<CapitaineDiplome>(GetJsonFileFullName(PortsResources.CapitainesDiplomesJsonFile));
            Bateaux = new JsonFileDataSet<Bateau>(GetJsonFileFullName(PortsResources.BateauxJsonFile));
        }

        private static string GetJsonFileFullName(string jsonFileName)
        {
            var jsonFilesPath = Directory.Exists(PortsResources.JsonFilesPath_Home) ? 
                                    PortsResources.JsonFilesPath_Home : PortsResources.JsonFilesPath_Job;

            var retour = $"{jsonFilesPath}{jsonFileName}";
            return retour;
        }

    }
}
