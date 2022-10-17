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
                }

                //Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll()); Console.ReadKey();
                //Debug.ShowData(portsUnitOfWork.VilleRepository.Get(1)); Console.ReadKey();


                Func<Ville, bool> filtre = ville => ville.Nom.Contains("M");

            > METTRE UNE EXPRESSION A LA PLACE (pour les 2)
                //Debug.ShowData(portsUnitOfWork.VilleRepository.Find()); Console.ReadKey();
            }
        }

        //private static void Tester_PortsEFDbDataContextAdapter()
        //{
        //    PortsEFDbDataContext portsEFDbDataContext = (new PortsEFDbDataContextFactory()).GetDbContext();
        //    IPortsDataContext portsDataContext = new PortsEFDbDataContextAdapter(portsEFDbDataContext);

        //    using (
        //    PortsUnitOfWork portsUnitOfWork = new PortsUnitOfWork(portsDataContext as IPortsDataContext)
        //    //;
        //    )
        //    {
        //        portsUnitOfWork.VilleRepository.AddRange(GetVilles());
        //        //portsEFDbDataContext.Set<Ville>().Add(new Ville { Nom = "NewOne" });
        //        //Console.WriteLine(portsEFDbDataContext.Set<Ville>().Where(ville => ville.Nom.StartsWith("N")).Count());
        //        //Console.WriteLine(portsEFDbDataContext.Villes.Where(ville => ville.Nom.StartsWith("N")).Count());
        //        portsUnitOfWork.Commit();
        //    }
        //}

        //private static void Tester_PortsEFDbDataContextAdapterOld()
        //{
        //    PortsEFDbDataContext portsEFDbDataContext = (new PortsEFDbDataContextFactory()).GetDbContext();
        //    IPortsDataContext portsDataContext = new PortsEFDbDataContextAdapter(portsEFDbDataContext);

        //    using (
        //    PortsUnitOfWork portsUnitOfWork = new PortsUnitOfWork(portsDataContext)
        //    //;
        //    )
        //    {
        //        //portsEFDbDataContext.Villes.AddRange(GetVilles());

        //        //portsEFDbDataContext.Villes.Add(
        //        //    new Ville
        //        //    {
        //        //        Nom = "Caen",
        //        //    }
        //        //);



        //        portsEFDbDataContext.Villes.Add(
        //            new Ville
        //            {
        //                Nom = "Nantes",
        //            }
        //        );
        //        //portsEFDbDataContext.Set<Ville>();

        //        //var v = k as ICollection<Ville>;
        //        //Console.WriteLine(k is null);
        //        //Console.WriteLine(v is null);
        //        //portsUnitOfWork.VilleRepository.AddRange(GetVilles());

        //        //Debug.ShowData(portsUnitOfWork.VilleRepository.GetAll());

        //        //portsUnitOfWork.Commit();
        //    }

        //    PortsEFDbDataContext portsEFDbDataContext2 = (new PortsEFDbDataContextFactory()).GetDbContext();
        //    IPortsDataContext portsDataContext2 = new PortsEFDbDataContextAdapter(portsEFDbDataContext2);

        //    using (
        //    PortsUnitOfWork portsUnitOfWork = new PortsUnitOfWork(portsDataContext2)
        //    //;
        //    )
        //    {
        //        //using (
        //        //PortsUnitOfWork portsUnitOfWork = new PortsUnitOfWork(portsDataContext);
        //        ////;
        //        //)
        //        //{
        //        //}
        //        var v = new Ville
        //        {
        //            Nom = "Nantes5",
        //        };
        //        //portsEFDbDataContext2.Set<Ville>();
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        //portsEFDbDataContext2.Set<Ville>().Add(
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        portsEFDbDataContext2.Villes.Add(
        //            v
        //        );
        //        portsEFDbDataContext2.Villes.Add(
        //        new Ville
        //        {
        //            Nom = "Loo"
        //        });
        //        var l = new[]
        //        {
        //            new Ville { Nom="v1"},
        //            new Ville { Nom="v2"},
        //            new Ville { Nom="v10"},
        //        };
        //        Debug.ShowData(l.Where(ville => ville.Nom.StartsWith("v1")).ToList());
        //        //portsEFDbDataContext2.SaveChanges();
        //        //Debug.ShowData(portsEFDbDataContext2.Villes.Where(ville => ville.Nom.StartsWith("L")).ToList());
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        //portsEFDbDataContext2.Entry(v).Reload();
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        //portsEFDbDataContext2.Set<Ville>();
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        //Debug.ShowData(portsEFDbDataContext2.Villes.ToList());Console.ReadKey();
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        //portsEFDbDataContext2.SaveChanges();
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //        //Debug.ShowData(portsEFDbDataContext2.Villes.ToList());
        //        //Console.WriteLine(portsEFDbDataContext2.Villes.Count());
        //    }
        //}

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
                Debug.ShowData(portsUnitOfWork.PortRepository.Find(port => port.Nom.Contains("1"))); Console.ReadKey();

                portsUnitOfWork.Commit();
            }
        }


        //private static IEnumerable<int> GetV()
        //{
        //    yield return 10;
        //    yield return 100;
        //}



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