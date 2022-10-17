using System;

using Infra.DataContext.Interfaces;

namespace Infra.UnitsOfWork
{
    public abstract class AUnitOfWork
    {
        private readonly IDataContext dataContext;

        protected AUnitOfWork(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Commit()
        {
            dataContext.Save();
        }

        public void Dispose()
        {
            Console.WriteLine("DISPOSING unit of work .... !");
            dataContext.Dispose();
        }
    }
}
