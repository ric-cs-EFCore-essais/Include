using System;

namespace Infra.DataContext.Interfaces
{
    public interface IDataContext: IDisposable
    {
        void SaveChanges();
    }
}
