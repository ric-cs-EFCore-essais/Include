﻿using Infra.DataContext.Interfaces;

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
            dataContext.SaveChanges();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
