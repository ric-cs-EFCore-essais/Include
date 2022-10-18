using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataSet;
using Infra.DataContext.Properties;


namespace Infra.DataContext.Ports
{
    public class PortsJsonFilesDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsJsonFilesDataContext(): base()
        {
            Ports = new JsonFileDataSet<Port>(GetJsonFileFullName(Resources.PortsJsonFile));
            Villes = new JsonFileDataSet<Ville>(GetJsonFileFullName(Resources.VillesJsonFile));
            Ancres = new JsonFileDataSet<Ancre>(GetJsonFileFullName(Resources.AncresJsonFile));
            Diplomes = new JsonFileDataSet<Diplome>(GetJsonFileFullName(Resources.DiplomesJsonFile));
            Capitaines = new JsonFileDataSet<Capitaine>(GetJsonFileFullName(Resources.CapitainesJsonFile));
        }

        private static string GetJsonFileFullName(string jsonFileName)
        {
            var retour = $"{Resources.JsonFilesPath}{jsonFileName}";
            return retour;
        }

    }
}
