using System;

namespace Infra.UnitsOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
