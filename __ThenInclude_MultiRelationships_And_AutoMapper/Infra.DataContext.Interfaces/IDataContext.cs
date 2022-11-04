using System;

namespace Infra.DataContext.Interfaces
{
    public interface IDataContext: IDisposable
    {
        void Save();

        bool HasMetaData { get; }
    }
}
