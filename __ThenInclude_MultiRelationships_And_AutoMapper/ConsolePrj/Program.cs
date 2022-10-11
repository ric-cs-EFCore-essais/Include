using System;
using System.Collections.Generic;
using System.Linq;

using Transverse.Common.DebugTools;

using Domain.Entities.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataContext.Ports;
using Infra.UnitsOfWork.Ports;

namespace ConsolePrj
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Tester_PortsJsonFilesDataContext();
            Tester_PortsEFDbDataContextAdapter();

            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

        private static void Tester_PortsEFDbDataContextAdapter()
        {
            PortsEFDbDataContext portsEFDbDataContext = (new PortsEFDbDataContextFactory()).GetDbContext();
            IPortsDataContext portsDataContext = new PortsEFDbDataContextAdapter(portsEFDbDataContext);

            using (PortsUnitOfWork portsUnitOfWork = new PortsUnitOfWork(portsDataContext))
            {
                //portsUnitOfWork.PortRepository.AddRange(GetPorts());

                //Debug.ShowData(unitOfWork.PortRepository.GetAll());
                //Debug.ShowData(portsUnitOfWork.PortRepository.Get(1));

                //portsUnitOfWork.Commit();
            }
        }

        private static void Tester_PortsJsonFilesDataContext()
        {
            IPortsDataContext portsDataContext = new PortsJsonFilesDataContext();

            using (PortsUnitOfWork portsUnitOfWork = new PortsUnitOfWork(portsDataContext))
            {
                //portsUnitOfWork.PortRepository.AddRange(GetPorts());

                //Debug.ShowData(unitOfWork.PortRepository.GetAll());
                //Debug.ShowData(portsUnitOfWork.PortRepository.Get(1));

                portsUnitOfWork.Commit();
            }
        }

        private static IList<Port> GetPorts()
        {
            var retours = new List<Port>
            {
                new Port
                {
                    Id = 1,
                    Nom = "Port 1 de Marseille",
                    Bateaux = new List<Bateau>
                    {
                        new Bateau { Id = 1, Nom = "P1M - Bateau1" },
                        new Bateau { Id = 2, Nom = "P1M - Bateau2" },
                        new Bateau { Id = 3, Nom = "P1M - Bateau3" },
                        new Bateau { Id = 4, Nom = "P1M - Bateau4" },
                    }
                },

                new Port
                {
                    Id = 2,
                    Nom = "Port 2 de Marseille",
                    Bateaux = new List<Bateau>
                    {
                        new Bateau { Id = 5, Nom = "P2M - Bateau1" },
                        new Bateau { Id = 6, Nom = "P2M - Bateau2" },
                        new Bateau { Id = 7, Nom = "P2M - Bateau3" },
                        new Bateau { Id = 8, Nom = "P2M - Bateau4" },
                    }
                },
            };

            return retours;
        }
    }
}