using Microsoft.EntityFrameworkCore;

namespace Infra.DataContext.EF.Interfaces
{
    public interface IDbDataContextFactory<TDbDataContext>
        where TDbDataContext : DbContext
    {
        TDbDataContext GetSqlServerSingleton();

        TDbDataContext GetSqlServerInstance();
    }
}