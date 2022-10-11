using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Transverse.Common.DebugTools;  //Issu d'un Nuget perso. mis dans ./../../../../____Common/zzMyLocalPublishedPackages/

using Infra.Common.DataAccess.Interfaces;  //Issu d'un Nuget perso. mis dans ./../../../../____Common/zzMyLocalPublishedPackages/
using Infra.Common.DataAccess;  //Issu d'un Nuget perso. mis dans ./../../../../____Common/zzMyLocalPublishedPackages/

using Infra.DataContext.Ports;

namespace ConsolePrj
{
    //Classe nécessaire pour que l'objet DbContext puisse être créé par EF, dans un environnement non ASP.NET (ici envir. Console).
    //Seule la méthode CreateDbContext lui est utile.
    public class PortsEFDbDataContextFactory : IDesignTimeDbContextFactory<PortsEFDbDataContext> //Du fait que la présente classe implémente cette interface là,
    {                                                                                                // EF saura comment créer son instance de type
                                                                                                     //  MyApplicationDbContext
                                                                                                     // (la méthode CreateDbContext sera alors appelée automatiquement).
        private PortsEFDbDataContext _dbContext;

        public PortsEFDbDataContextFactory() //Constructeur appelé automatiquement par EF pour son besoin...
            : this(false) //Appel perso. vers mon constructeur perso. qui lui prend un param.
        {
        }

        public PortsEFDbDataContextFactory(bool appelManuel) //Constructeur perso. !
        {
            var text = (appelManuel) ? "(appel manuel)" : "(appel automatique)";
            Console.WriteLine($"\n\n - Instanciation de MyApplicationDbContextFactory {text} -\n\n");
        }

        public PortsEFDbDataContext CreateDbContext(string[] args) //sera appelée automatiquement par EF en cas de besoin
        {
            IDBServerAccessConfiguration dbServerAccessConfiguration = new DBServerAccessConfiguration()
            {
                DatabaseName = "Essais_EF_ThenInclude_MultiRelationships"
            };
            Debug.ShowData(dbServerAccessConfiguration);

            var connectionString = dbServerAccessConfiguration.GetConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<PortsEFDbDataContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new PortsEFDbDataContext(optionsBuilder.Options);
        }

        public PortsEFDbDataContext GetDbContext() //Méthode perso. !
        {
            if (this._dbContext is null)
            {
                this._dbContext = CreateDbContext(new[] { "" });
            }

            return this._dbContext;
        }
    }
}