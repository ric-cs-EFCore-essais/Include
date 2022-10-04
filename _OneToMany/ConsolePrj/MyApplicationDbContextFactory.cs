using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using DataAccess;
using System;

namespace ConsolePrj
{
    //Classe nécessaire pour que l'objet DbContext puisse être créé par EF, dans un environnement non ASP.NET (ici envir. Console).
    //Seule la méthode CreateDbContext lui est utile.
    public class MyApplicationDbContextFactory : IDesignTimeDbContextFactory<MyApplicationDbContext> //Du fait que la présente classe implémente cette interface là,
    {                                                                                                // EF saura comment créer son instance de type
                                                                                                     //  MyApplicationDbContext
                                                                                                     // (la méthode CreateDbContext sera alors appelée automatiquement).
        private MyApplicationDbContext _dbContext;

        public MyApplicationDbContextFactory() //Constructeur appelé automatiquement par EF pour son besoin...
            : this(false) //Appel perso. vers mon constructeur perso. qui lui prend un param.
        {
        }

        public MyApplicationDbContextFactory(bool appelManuel) //Constructeur perso. !
        {
            var text = (appelManuel) ? "(appel manuel)" : "(appel automatique)";
            Console.WriteLine($"\n\n - Instanciation de MyApplicationDbContextFactory {text} -\n\n");
        }

        public MyApplicationDbContext CreateDbContext(string[] args) //sera appelée automatiquement par EF en cas de besoin
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyApplicationDbContext>();

            string server = string.Empty;
            string user = string.Empty;
            string password = string.Empty;
            string databaseName = string.Empty;

            //server = @"PC-RP-VM-W10PRO\SQL_SERVER_2019"; user = "SA2"; databaseName = "Essais_EF_Include_OneToMany"; //Home

            server = "localhost,17433"; user = "SA3"; databaseName = "Essais_EF_Include_OneToMany";  //Job

            password = "SS2019PSw";

            optionsBuilder.UseSqlServer(@$"Server={server}; Database={databaseName}; User Id={user}; Password={password};");
            var retour = new MyApplicationDbContext(optionsBuilder.Options);

            return retour;
        }

        public MyApplicationDbContext GetDbContext() //Méthode perso. !
        {
            if (this._dbContext is null)
            {
                this._dbContext = CreateDbContext(new[] { "" });
            }

            return this._dbContext;
        }
    }
}