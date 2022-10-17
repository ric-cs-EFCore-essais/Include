using Microsoft.EntityFrameworkCore;

using Infra.Common.DataAccess.Interfaces;  //Issu d'un Nuget perso. mis dans ./../../../../____Common/zzMyLocalPublishedPackages/

namespace Infra.DataContext.EF.Ports
{
    public abstract class ADbDataContextFactory<TDbDataContext>
        where TDbDataContext : DbContext
    {
        private readonly IDBServerAccessConfiguration dbServerAccessConfiguration;
        private TDbDataContext sqlServerSingleton;

        protected abstract TDbDataContext CreateDbDataContext(DbContextOptions<TDbDataContext> options); //<<<<<<<< Spécifique

        protected ADbDataContextFactory(IDBServerAccessConfiguration dbServerAccessConfiguration)
        {
            this.dbServerAccessConfiguration = dbServerAccessConfiguration;
        }

        public TDbDataContext GetSqlServerSingleton()
        {
            var retour = sqlServerSingleton ?? (sqlServerSingleton = GetSqlServerInstance());
            return retour;
        }

        public TDbDataContext GetSqlServerInstance()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbDataContext>();
            ConfigureOptionsBuilder(optionsBuilder);

            return CreateDbDataContext(optionsBuilder.Options);
        }

        private void ConfigureOptionsBuilder(DbContextOptionsBuilder<TDbDataContext> optionsBuilder)
        {
            var connectionString = dbServerAccessConfiguration.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}