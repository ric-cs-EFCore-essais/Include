using System;
using System.Linq;
using System.Linq.Expressions;

using Infra.Common.DataAccess.Interfaces;
using Transverse.Common.DebugTools;

using Domain.UnitsOfWork.Interfaces.Ports;
using Infra.DataContext.EF.Interfaces;

using Domain.Entities.Ports;
using Infra.UnitsOfWork.Factories.Ports;
using Infra.DataContext.EF.Ports;
using Tests.FakeData.Ports;
using Infra.Controllers.Ports;
using Infra.DependenciesInjection.Ports.Factories;
using Infra.DependenciesInjection.Ports;
using Infra.Config.DataAccess;

namespace ConsolePrj
{
    static class Program
    {
        static Chrono chrono;

        static void Main(string[] requestArgs)
        {
            SeedRepositoriesIfEmpty();

            //---------------
            //TesterGet(); return;

            //---------------
            TesterRequests(requestArgs);

            //---------------
            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

        private static void SeedRepositoriesIfEmpty()
        {
            if (MyConfig.DataAccessConfig.DataStoreMode == DataStoreMode.EF)
            {
                SeedRepositoriesIfEmpty_EF();
            }
            else if (MyConfig.DataAccessConfig.DataStoreMode == DataStoreMode.JSON)
            {
                SeedRepositoriesIfEmpty_JSON();
            }

        }

        //=========================================================================================================================================

        private static void TesterRequests(string[] requestArgs)
        {
            //requestArgs = new[] { "get/ports" };
            //requestArgs = new[] { "get/ports/fulldata" };
            //requestArgs = new[] { "get/port", "2"};
            //requestArgs = new[] { "get/port/fulldata", "2" };
            //requestArgs = new[] { "post/port/add", "NewPort", "3"}; //Nom, VilleId

            //requestArgs = new[] { "get/villes/withnamecontaining", "n"};
            //requestArgs = new[] { "post/ville/add", "newVilleName"}; //Nom

            //requestArgs = new[] { "post/ancre/add", "410"}; //Poids

            //requestArgs = new[] { "post/capitaine/add", "CaptainChoc"}; //Nom

            //requestArgs = new[] { "post/diplome/add", "BAFA" }; //Intitule

            //requestArgs = new[] { "post/bateau/add", "Le MALU", "1", "12", "3" }; //Nom, PortId, AncreId, CapitaineId

            //requestArgs = new[] { "post/capitainediplome/add", "3", "4" "1975" }; //CapitaineId, DiplomeId, AnneeObtention
            //requestArgs = new[] { "post/capitainediplomes/add", "2", "3-1975;2-1986" }; //CapitaineId,  DiplomeId-AnneeObtention;DiplomeId-AnneeObtention;...

            TreatRequest(requestArgs);
        }

        private static void TreatRequest(string[] requestArgs)
        {
            FrontController frontController = DependenciesInjectionConfiguration.GetSingleton(MyConfig.DataAccessConfig).GetFrontController();

            Console.WriteLine("\nREQUÊTE:");
            Console.WriteLine("  "+Debug.GetSerializedData(requestArgs));

            string response = frontController.TreatRequest(requestArgs);

            Console.WriteLine("\nRÉPONSE (serialized) : ");
            Console.WriteLine("  " + response);
        }

        private static void TesterGet()
        {
            chrono = new Chrono();

            if (MyConfig.DataAccessConfig.DataStoreMode == DataStoreMode.EF)
            {
                Tester_GetPortsDbDataContext_EF();
            }
            else if (MyConfig.DataAccessConfig.DataStoreMode == DataStoreMode.JSON)
            {
                Tester_GetPortsJsonFilesDataContext();
            }
        }


        //====================================================== via EF ==================================================================================
        private static void Tester_GetPortsDbDataContext_EF()
        {
            Console.WriteLine("\n\n***********  Tester_PortsDbDataContext_EF() ***********\n\n");

            using (IPortsUnitOfWork portsUnitOfWork = GetUnitOfWork_EF())
            {
                //>>>Debug.ShowData gère désormais bien les dépendances cycliques (ici : Capitaine -> CapitainesDiplomes -> Capitaine, et Diplome -> CapitaineDiplomes -> Diplome). (Gère en ignorant).

                chrono.Start();
                var port = portsUnitOfWork.PortRepository.Get(2);
                chrono.StopAndShowDuration();
                Debug.ShowData(port);
                Console.ReadKey(); Console.WriteLine("\n\n"); return;

                //Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey(); Console.WriteLine("\n\n");


                Expression<Func<Ville, bool>> filtreExpression = ville => ville.Nom.StartsWith("M"); //Conversion auto. du filtre, en LINQ Expression !
                Debug.ShowData(portsUnitOfWork.VilleRepository.Find(filtreExpression)); Console.ReadKey();
                //Debug.ShowData(portsUnitOfWork.VilleRepository.Find(ville => ville.Nom.StartsWith("M"))); Console.ReadKey(); //Autre syntaxe : conversion auto. du filtre, en LINQ Expression !
                Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey(); Console.WriteLine("\n\n");
                Debug.ShowData(portsUnitOfWork.VilleRepository.Get(1)); Console.ReadKey(); Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetByPort(portId: 3)); Console.ReadKey(); Console.WriteLine("\n\n");
            }
        }
        private static IPortsUnitOfWork GetUnitOfWork_EF()
        {
            PortsDBServerAccessConfigurationFactory portsDBServerAccessConfigurationFactory = new PortsDBServerAccessConfigurationFactory();
            IDBServerAccessConfiguration portsDBServerAccessConfiguration = portsDBServerAccessConfigurationFactory.GetSingleton();

            IDbDataContextFactory<PortsDbDataContext> dbDataContextFactory = Infra.DataContext.EF.Ports.PortsDbDataContextFactory.GetSingleton(portsDBServerAccessConfiguration);

            return new Infra.UnitsOfWork.EF.Factories.Ports.PortsUnitOfWorkFactory(dbDataContextFactory).GetInstance();
        }
        private static void SeedRepositoriesIfEmpty_EF()
        {
            Console.WriteLine("\n\n***********  SeedRepositoriesIfEmpty_EF() ***********\n\n");

            using (IPortsUnitOfWork portsUnitOfWork = GetUnitOfWork_EF())
            {
                SeedRepositoriesIfEmpty(portsUnitOfWork);
            }
        }

        //====================================================== JSON ==================================================================================

        private static void Tester_GetPortsJsonFilesDataContext()
        {
            Console.WriteLine("\n\n***********  Tester_PortsJsonFilesDataContext() ***********\n\n");

            using (IPortsUnitOfWork portsUnitOfWork = new PortsUnitOfWorkFactory().GetInstance())
            {
                SeedRepositoriesIfEmpty(portsUnitOfWork);

                //>>> Debug.ShowData gère désormais bien les dépendances cycliques (ici : Capitaine -> CapitainesDiplomes -> Capitaine, et Diplome -> CapitaineDiplomes -> Diplome). (Gère en ignorant).

                chrono.Start();
                var port = portsUnitOfWork.PortRepository.Get(2);
                chrono.StopAndShowDuration();
                Debug.ShowData(port); Console.ReadKey(); Console.WriteLine("\n\n"); return;

                //chrono.Start();
                //var ports = portsUnitOfWork.PortRepository.GetAll();
                //chrono.StopAndShowDuration();
                //Debug.ShowData(ports); Console.ReadKey(); Console.WriteLine("\n\n"); return;

                Expression<Func<Port, bool>> filtreExpression = port => port.Nom.Contains("4"); //Conversion auto. du filtre, en LINQ Expression !
                Debug.ShowData(portsUnitOfWork.PortRepository.Find(filtreExpression)); Console.ReadKey();
                //Debug.ShowData(portsUnitOfWork.PortRepository.Find(port => port.Nom.Contains("4"))); Console.ReadKey(); //Autre syntaxe : conversion auto. du filtre, en LINQ Expression !
                Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.PortRepository.GetAll()); Console.ReadKey(); Console.WriteLine("\n\n");
                Debug.ShowData(portsUnitOfWork.PortRepository.Get(3)); Console.ReadKey(); Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetByPort(portId: 3)); Console.ReadKey(); Console.WriteLine("\n\n");
                Debug.ShowData(portsUnitOfWork.VilleRepository.Get(1)); Console.ReadKey(); Console.WriteLine("\n\n");

            }
        }
        private static void SeedRepositoriesIfEmpty_JSON()
        {
            Console.WriteLine("\n\n***********  SeedRepositoriesIfEmpty_JSON() ***********\n\n");

            using (IPortsUnitOfWork portsUnitOfWork = new PortsUnitOfWorkFactory().GetInstance())
            {
                SeedRepositoriesIfEmpty(portsUnitOfWork);
            }
        }

        //============================================================================================================================================================
        //============================================================================================================================================================
        private static void SeedRepositoriesIfEmpty(IPortsUnitOfWork portsUnitOfWork)
        {
            if (!portsUnitOfWork.VilleRepository.GetAll().Any())
            {
                portsUnitOfWork.VilleRepository.AddRange(PortsFakeData.GetVilles());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Villes DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.PortRepository.GetAll().Any())
            {
                portsUnitOfWork.PortRepository.AddRange(PortsFakeData.GetPorts());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Ports DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.AncreRepository.GetAll().Any())
            {
                portsUnitOfWork.AncreRepository.AddRange(PortsFakeData.GetAncres());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Ancres DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.DiplomeRepository.GetAll().Any())
            {
                portsUnitOfWork.DiplomeRepository.AddRange(PortsFakeData.GetDiplomes());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Diplomes DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.CapitaineRepository.GetAll().Any())
            {
                portsUnitOfWork.CapitaineRepository.AddRange(PortsFakeData.GetCapitaines());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Capitaines DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.CapitaineDiplomeRepository.GetAll().Any())
            {
                portsUnitOfWork.CapitaineDiplomeRepository.AddRange(PortsFakeData.GetCapitainesDiplomes());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE CapitainesDiplomes DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.BateauRepository.GetAll().Any())
            {
                portsUnitOfWork.BateauRepository.AddRange(PortsFakeData.GetBateaux());
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Bateaux DONE"); Console.ReadKey();
            }
        }
    }
}