using System;

namespace Domain.UnitsOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
