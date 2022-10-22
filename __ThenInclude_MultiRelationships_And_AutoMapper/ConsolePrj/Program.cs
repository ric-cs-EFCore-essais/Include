﻿using System;
using System.Linq;
using System.Linq.Expressions;

using Infra.Common.DataAccess.Interfaces;
using Transverse.Common.DebugTools;

using Infra.UnitsOfWork.Interfaces.Ports;
using Infra.DataContext.EF.Interfaces;

using Domain.Entities.Ports;
using Infra.UnitsOfWork.Factories.Ports;
using Infra.DataContext.EF.Ports;
using Tests.FakeData.Ports;


namespace ConsolePrj
{
    static class Program
    {
        static void Main(string[] args)
        {
            Tester_PortsJsonFilesDataContext();
            //Tester_PortsDbDataContext();

            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

        private static void Tester_PortsDbDataContext()
        {
            Console.WriteLine("\n\n***********  Tester_PortsDbDataContext() ***********\n\n");

            PortsDBServerAccessConfigurationFactory portsDBServerAccessConfigurationFactory = new PortsDBServerAccessConfigurationFactory();
            IDBServerAccessConfiguration portsDBServerAccessConfiguration = portsDBServerAccessConfigurationFactory.GetSingleton();

            IDbDataContextFactory<PortsDbDataContext> dbDataContextFactory = Infra.DataContext.EF.Ports.PortsDbDataContextFactory.GetSingleton(portsDBServerAccessConfiguration);
            using (IPortsUnitOfWork portsUnitOfWork = new Infra.UnitsOfWork.EF.Factories.Ports.PortsUnitOfWorkFactory(dbDataContextFactory).GetInstance())
            {
                SeedRepositoriesIfEmpty(portsUnitOfWork);

                var port = portsUnitOfWork.PortRepository.Get(2);
                Debug.ShowData(port); //Debug.ShowData gère désormais bien les dépendances cycliques (ici : Capitaine -> CapitainesDiplomes -> Capitaine, et Diplome -> CapitaineDiplomes -> Diplome). (Gère en ignorant).
                Console.ReadKey(); Console.WriteLine("\n\n");
                //return;

                //Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey(); Console.WriteLine("\n\n");


                Expression<Func<Ville, bool>> filtreExpression = ville => ville.Nom.StartsWith("M"); //Conversion auto. du filtre, en LINQ Expression !
                Debug.ShowData(portsUnitOfWork.VilleRepository.Find(filtreExpression)); Console.ReadKey();
                //Debug.ShowData(portsUnitOfWork.VilleRepository.Find(ville => ville.Nom.StartsWith("M"))); Console.ReadKey(); //Autre syntaxe : conversion auto. du filtre, en LINQ Expression !
                Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey(); Console.WriteLine("\n\n");
                Debug.ShowData(portsUnitOfWork.VilleRepository.Get(1)); Console.ReadKey(); Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetByPort(portId:3)); Console.ReadKey(); Console.WriteLine("\n\n");
            }
        }

        private static void Tester_PortsJsonFilesDataContext()
        {
            Console.WriteLine("\n\n***********  Tester_PortsJsonFilesDataContext() ***********\n\n");

            using (IPortsUnitOfWork portsUnitOfWork = new PortsUnitOfWorkFactory().GetInstance())
            {
                var autoInitIds = true;
                SeedRepositoriesIfEmpty(portsUnitOfWork, autoInitIds);

                var port = portsUnitOfWork.PortRepository.Get(2);
                Debug.ShowData(port); //Debug.ShowData gère désormais bien les dépendances cycliques (ici : Capitaine -> CapitainesDiplomes -> Capitaine, et Diplome -> CapitaineDiplomes -> Diplome). (Gère en ignorant).
                Console.ReadKey(); Console.WriteLine("\n\n");
                //return;


                //Debug.ShowData(portsUnitOfWork.PortRepository.GetAll()); Console.ReadKey(); Console.WriteLine("\n\n");


                Expression<Func<Port, bool>> filtreExpression = port => port.Nom.Contains("4"); //Conversion auto. du filtre, en LINQ Expression !
                Debug.ShowData(portsUnitOfWork.PortRepository.Find(filtreExpression)); Console.ReadKey();
                //Debug.ShowData(portsUnitOfWork.PortRepository.Find(port => port.Nom.Contains("4"))); Console.ReadKey(); //Autre syntaxe : conversion auto. du filtre, en LINQ Expression !
                Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.PortRepository.GetAll());Console.ReadKey(); Console.WriteLine("\n\n");
                Debug.ShowData(portsUnitOfWork.PortRepository.Get(3)); Console.ReadKey(); Console.WriteLine("\n\n");

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetByPort(portId: 3)); Console.ReadKey(); Console.WriteLine("\n\n");
                Debug.ShowData(portsUnitOfWork.VilleRepository.Get(1)); Console.ReadKey(); Console.WriteLine("\n\n");

            }
        }

        private static void SeedRepositoriesIfEmpty(IPortsUnitOfWork portsUnitOfWork, bool autoInitIds = false)
        {
            if (!portsUnitOfWork.VilleRepository.GetAll().Any())
            {
                portsUnitOfWork.VilleRepository.AddRange(PortsFakeData.GetVilles(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Villes DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.PortRepository.GetAll().Any())
            {
                portsUnitOfWork.PortRepository.AddRange(PortsFakeData.GetPorts(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Ports DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.AncreRepository.GetAll().Any())
            {
                portsUnitOfWork.AncreRepository.AddRange(PortsFakeData.GetAncres(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Ancres DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.DiplomeRepository.GetAll().Any())
            {
                portsUnitOfWork.DiplomeRepository.AddRange(PortsFakeData.GetDiplomes(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Diplomes DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.CapitaineRepository.GetAll().Any())
            {
                portsUnitOfWork.CapitaineRepository.AddRange(PortsFakeData.GetCapitaines(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Capitaines DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.CapitaineDiplomeRepository.GetAll().Any())
            {
                portsUnitOfWork.CapitaineDiplomeRepository.AddRange(PortsFakeData.GetCapitainesDiplomes(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE CapitainesDiplomes DONE"); Console.ReadKey();
            }

            if (!portsUnitOfWork.BateauRepository.GetAll().Any())
            {
                portsUnitOfWork.BateauRepository.AddRange(PortsFakeData.GetBateaux(autoInitIds));
                portsUnitOfWork.Commit();
                Console.WriteLine("REMPLISSAGE Bateaux DONE"); Console.ReadKey();
            }
        }
    }
}