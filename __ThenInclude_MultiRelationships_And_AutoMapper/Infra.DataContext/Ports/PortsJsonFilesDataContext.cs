using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.Properties.Ports;

namespace Infra.DataContext.Ports
{
    public class PortsJsonFilesDataContext : APortsDataContext, IPortsDataContext
    {
        public PortsJsonFilesDataContext(): base()
        {
            var jsonFilesDataContext = new JsonFilesDataContext(GetJsonFilesRootPath()); //Car on ne peut EN PLUS hériter de JsonFilesDataContext (pas d'héritage multiple)

            Ports = jsonFilesDataContext.GetJsonFileDataSet<Port>(PortsResources.PortsJsonFileName);
            Villes = jsonFilesDataContext.GetJsonFileDataSet<Ville>(PortsResources.VillesJsonFileName);
            Ancres = jsonFilesDataContext.GetJsonFileDataSet<Ancre>(PortsResources.AncresJsonFileName);
            Diplomes = jsonFilesDataContext.GetJsonFileDataSet<Diplome>(PortsResources.DiplomesJsonFileName);
            Capitaines = jsonFilesDataContext.GetJsonFileDataSet<Capitaine>(PortsResources.CapitainesJsonFileName);
            CapitainesDiplomes = jsonFilesDataContext.GetJsonFileDataSet<CapitaineDiplome>(PortsResources.CapitainesDiplomesJsonFileName);
            Bateaux = jsonFilesDataContext.GetJsonFileDataSet<Bateau>(PortsResources.BateauxJsonFileName);
        }

        private static string GetJsonFilesRootPath()
        {
            var retour = (Infra.Common.Environment.IsHome()) ? PortsResources.JsonFilesRootPath_Home : PortsResources.JsonFilesRootPath_Job;
            return retour;
        }
    }
}
