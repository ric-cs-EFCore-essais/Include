using System;
using System.Collections.Generic;
using System.Linq;

using Transverse.Common.DebugTools;

using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataContext.Ports;
using Infra.UnitsOfWork.Ports;
using System.Collections.ObjectModel;
using Domain.Repositories.Interfaces.Ports;
using Infra.UnitsOfWork.Factories.Ports;
using Infra.UnitsOfWork.Interfaces.Ports;
using Infra.DataContext.EF.Interfaces;
using Infra.DataContext.EF.Ports;
using Infra.Common.DataAccess.Interfaces;

namespace ConsolePrj
{
    //class Toto : IDisposable
    //{
    //    public void Dispose()
    //    {
    //        Console.WriteLine("ICI");
    //    }
    //}
    static class Program
    {
        static void Main(string[] args)
        {
            //Tester_PortsJsonFilesDataContext();
            Tester_PortsDbDataContext();

            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

        private static void Tester_PortsDbDataContext()
        {
            PortsDBServerAccessConfigurationFactory portsDBServerAccessConfigurationFactory = new PortsDBServerAccessConfigurationFactory();
            IDBServerAccessConfiguration portsDBServerAccessConfiguration = portsDBServerAccessConfigurationFactory.GetSingleton();

            IDbDataContextFactory<PortsDbDataContext> dbDataContextFactory = Infra.DataContext.EF.Ports.PortsDbDataContextFactory.GetSingleton(portsDBServerAccessConfiguration);
            using (IPortsUnitOfWork portsUnitOfWork = new Infra.UnitsOfWork.EF.Factories.Ports.PortsUnitOfWorkFactory(dbDataContextFactory).GetInstance())
            {
                //Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey();

                if (!portsUnitOfWork.VilleRepository.GetAll().Any()) 
                {
                    portsUnitOfWork.VilleRepository.AddRange(GetVilles());
                    portsUnitOfWork.VilleRepository.Add(new Ville { Nom = "Gibraltar" });
                    portsUnitOfWork.VilleRepository.Add(new Ville { Nom = "Miami" });
                    portsUnitOfWork.Commit();
                    Console.WriteLine("DONE"); Console.ReadKey();
                }

                Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey();
                Debug.ShowData(portsUnitOfWork.VilleRepository.Get(1)); Console.ReadKey();


                Debug.ShowData(portsUnitOfWork.VilleRepository.Find(ville => ville.Nom.StartsWith("M"))); Console.ReadKey(); //Conversion auto. du filtre, en LINQ Expression !
            }
        }

        private static void Tester_PortsJsonFilesDataContext()
        {
            using (IPortsUnitOfWork portsUnitOfWork = new PortsUnitOfWorkFactory().GetInstance())
            {
                Debug.ShowData(portsUnitOfWork.PortRepository.GetAll()); Console.ReadKey();

                portsUnitOfWork.PortRepository.AddRange(GetPorts());
                portsUnitOfWork.PortRepository.Add(new Port { Id = 3, Nom = "33111" });
                portsUnitOfWork.PortRepository.Add(new Port { Id = 4, Nom = "4444111" });

                Debug.ShowData(portsUnitOfWork.PortRepository.GetAll());Console.ReadKey();
                Debug.ShowData(portsUnitOfWork.PortRepository.Get(1)); Console.ReadKey();
                Debug.ShowData(portsUnitOfWork.PortRepository.Find(port => port.Nom.Contains("1"))); Console.ReadKey(); //Conversion auto. du filtre, en LINQ Expression !

                portsUnitOfWork.Commit();
            }
        }


        private static IList<Ville> GetVilles()
        {
            var retours = new List<Ville>
            {
                new Ville
                {
                    Nom = "Marseille",
                },

                new Ville
                {
                    Nom = "La Rochelle",
                },

                new Ville
                {
                    Nom = "Lisieux",
                },

                new Ville
                {
                    Nom = "Fréjus",
                },

                new Ville
                {
                    Nom = "Cannes",
                },

                new Ville
                {
                    Nom = "Nice",
                },

            };

            return retours;
        }

        private static IList<Port> GetPorts()
        {
            var retours = new List<Port>
            {
                new Port
                {
                    //Id = 1,
                    Nom = "Port 1 de Marseille",
                    Bateaux = new List<Bateau>
                    {
                        new Bateau { /*Id = 1,*/ Nom = "P1M - Bateau1" },
                        new Bateau { /*Id = 2,*/ Nom = "P1M - Bateau2" },
                        new Bateau { /*Id = 3,*/ Nom = "P1M - Bateau3" },
                        new Bateau { /*Id = 4,*/ Nom = "P1M - Bateau4" },
                    }
                },

                new Port
                {
                    //Id = 2,
                    Nom = "Port 2 de Marseille",
                    Bateaux = new List<Bateau>
                    {
                        new Bateau { /*Id = 5,*/ Nom = "P2M - Bateau1" },
                        new Bateau { /*Id = 6,*/ Nom = "P2M - Bateau2" },
                        new Bateau { /*Id = 7,*/ Nom = "P2M - Bateau3" },
                        new Bateau { /*Id = 8,*/ Nom = "P2M - Bateau4" },
                    }
                },
            };

            return retours;
        }
    }
}