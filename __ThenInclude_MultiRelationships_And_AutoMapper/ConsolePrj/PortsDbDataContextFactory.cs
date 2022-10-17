using System;

using Microsoft.EntityFrameworkCore.Design;

using Infra.Common.DataAccess.Interfaces;  //Issu d'un Nuget perso. mis dans ./../../../../____Common/zzMyLocalPublishedPackages/

using Infra.DataContext.EF.Interfaces;
using Infra.DataContext.EF.Ports;

namespace ConsolePrj
{
    //  CETTE CLASSE SERT UNIQUEMENT POUR L'INSTANCIATION DU DbContext, lorsque qu'EF en a besoin.
    //  Elle est sollicitée automatiquement lorsqu'EF lui-même, a besoin du DbContext.
    //
    //Classe nécessaire ICI, pour que l'objet DbContext puisse être créé par EF, dans un environnement non ASP.NET (ici envir. Console).
    //Seule la méthode CreateDbContext lui est utile. <<<<<<<<<
    public class PortsDbDataContextFactory : IDesignTimeDbContextFactory<PortsDbDataContext> //Du fait que la présente classe implémente cette interface là,
    {                                                                                        // EF saura comment créer son instance de type
                                                                                             //  PortsDbDataContext
                                                                                             // (la méthode CreateDbContext sera alors appelée automatiquement).
        private IDBServerAccessConfiguration dbServerAccessConfiguration; //Type perso.

        private IDbDataContextFactory<PortsDbDataContext> realFactory; //Type perso.

        public PortsDbDataContextFactory() //Constructeur appelé automatiquement par EF pour son besoin...
            : this((new PortsDBServerAccessConfigurationFactory()).GetSingleton()) //Appel perso. vers mon constructeur perso. qui lui, prend 1 param.
        {
        }

        private PortsDbDataContextFactory(IDBServerAccessConfiguration dbServerAccessConfiguration) //Constructeur perso. !
        {
            var text = "(appel automatique)";
            Console.WriteLine($"\n\n * Constructeur de {this.GetType().Name} - {text} *\n\n");

            this.dbServerAccessConfiguration = dbServerAccessConfiguration;
        }

        public PortsDbDataContext CreateDbContext(string[] args) //sera appelée automatiquement par EF en cas de besoin
        {
            var retour = GetSqlServerDbContextSingleton();
            return retour;
        }

        private PortsDbDataContext GetSqlServerDbContextSingleton() //Méthode perso. !
        {
            var retour = GetRealFactory().GetSqlServerSingleton();
            return retour;
        }

        private PortsDbDataContext GetDbContextInstance() //Méthode perso. !
        {
            var retour = GetRealFactory().GetSqlServerInstance();
            return retour;
        }

        private IDbDataContextFactory<PortsDbDataContext> GetRealFactory() //Méthode perso. !
        {
            var retour = realFactory ?? (realFactory = CreateRealFactory());
            return retour;
        }

        private IDbDataContextFactory<PortsDbDataContext> CreateRealFactory() //Méthode perso. !
        {
            var retour = Infra.DataContext.EF.Ports.PortsDbDataContextFactory.GetSingleton(dbServerAccessConfiguration);
            return retour;

        }
    }
}