//using System;

//using Microsoft.EntityFrameworkCore;

//using Infra.DataContext.Interfaces.Ports;

//using Domain.Entities.Ports;
//using Domain.Repositories.Interfaces;

//namespace Infra.DataContext.Ports
//{
//    public class PortsEFDbDataContextAdapter : IPortsDataContext
//    {
//        private readonly PortsEFDbDataContext portsEFDbDataContext;


//        public IEnumerableQueryable<Port> Ports
//        {
//            get => portsEFDbDataContext.Ports as IEnumerableQueryable<Port>;
//        }

//        public IEnumerableQueryable<Ville> Villes
//        {
//            get => portsEFDbDataContext.Villes as IEnumerableQueryable<Ville>;
//        }


//        public PortsEFDbDataContextAdapter(PortsEFDbDataContext portsEFDbDataContext)
//        {
//            this.portsEFDbDataContext = portsEFDbDataContext;
//        }

//        public void Dispose()
//        {
//            Console.WriteLine("portsEFDbDataContext.Dispose !!");
//            portsEFDbDataContext.Dispose();
//        }

//        public void SaveChanges()
//        {
//            portsEFDbDataContext.SaveChanges();
//        }
//    }
//}
