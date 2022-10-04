using System;
using System.Linq;
using System.Text.Json;

using Microsoft.EntityFrameworkCore; //Pour la méthode Include() d'un DbSet, ainsi que pour la méthode AsNoTracking().

using DataAccess;
using Domaine.MyEntities;


namespace ConsolePrj
{
    static class Program
    {
        private static MyApplicationDbContext myDbContext;

        static void Main()
        {
            var myDbContextFactory = new MyApplicationDbContextFactory(appelManuel: true);
            myDbContext = myDbContextFactory.GetDbContext();

            PlaceDataIfBaseVierge();

            DisplayLivres();
            Console.ReadKey();


            DisplayBibliothequesSansDetailLivres();
            Console.ReadKey();

            DisplayBibliothequesAvecDetailLivres();
            Console.ReadKey();


            ModifierLivreDId2();
            Console.ReadKey();

            DisplayLivres();
            Console.ReadKey();
        }

        private static void ModifierLivreDId2()
        {
            var idLivreAModifier = 2;
            Console.WriteLine($"\n\n ----- Modif. Titre du Livre d'id {idLivreAModifier} ---- \n");

            var livreAModifier = myDbContext.Livres.Find(idLivreAModifier);
            livreAModifier.Titre += " modified! ";
            myDbContext.SaveChanges();
        }

        private static void DisplayLivres()
        {
            Console.WriteLine("\n\n ----- Liste des Livres ---- \n");
            //ShowData(myDbContext.Livres); //<< Non pas directement comme ça, car comme il s'agit de lazy loading, le reader Json dans ShowData() va vouloir lire un truc pas encore récupéré, un truc comme ça :)

            // .AsNoTracking<Livre>() ci-dessous sert JUSTE pour ne pas que les livres soient mis en cache,
            //    (en effet ma connexion (usage du même DbContext tout du long, reste ouverte tout du long de mon essai))
            //    En effet, si mise en cache il y avait, mon exemple ne serait pas démonstratif, et la liste des Livres serait déjà chargée
            //    VU QUE ici DisplayLivres() est appelée en tout premier !
            ShowData(myDbContext.Livres
                    .AsNoTracking<Livre>()
                    .ToList()); //pour pouvoir utiliser ToList() sur un DbSet, il m'a fallu faire un : using System.Linq
        }

        private static void DisplayBibliothequesSansDetailLivres()
        {
            Console.WriteLine("\n\n ----- Liste des Bibliotheques MAIS sans détail des Livres ---- \n");

            ShowData(myDbContext.Bibliotheques.ToList()); //pour pouvoir utiliser ToList() sur un DbSet, il m'a fallu faire un : using System.Linq
        }

        private static void DisplayBibliothequesAvecDetailLivres()
        {
            Console.WriteLine("\n\n ----- Liste des Bibliotheques AVEC détail des Livres (grâce à l'usage de Include() sur le DbSet ---- \n");
            ShowData(myDbContext.Bibliotheques.Include(b => b.Livres).ToList()); //Pour pouvoir utiliser Include() sur le DbSet, il m'a fallu faire un : using Microsoft.EntityFrameworkCore
            //Grâce à Include() dans la requête, EF comprend qu'il doit pour chaque Bibliotheque traitée,
            // récupérer tous les enreg. Livre qui ont pour valeur de FK (champ BibliothequeId) : l'Id de la dite Bibliotheque.
            // (Rappel: la classe Bibliotheque a bien un membre : IList<Livre> Livres).
        }

        private static void PlaceDataIfBaseVierge() //Juste pour alimenter une première fois la base, si pas déjà fait.
        {
            if (estBaseVierge())
            {
                var idBiblio1 = 1;
                var idBiblio2 = 2;
                
                myDbContext.Bibliotheques.AddRange(new[]
                {
                    new Bibliotheque { Nom="Biblio 1" },
                    new Bibliotheque { Nom="Biblio 2" },
                });

                myDbContext.Livres.AddRange(new[]
                {
                    new Livre { Titre = "Livre1", DatePublication = DateTime.Parse("30/09/2022 14:24"), BibliothequeId = idBiblio1 },
                    new Livre { Titre = "Livre2", DatePublication = DateTime.Parse("21/10/2022 18:12"), BibliothequeId = idBiblio1 },
                    new Livre { Titre = "Livre3", BibliothequeId = idBiblio2 },
                    new Livre { Titre = "Livre4", BibliothequeId = idBiblio2, DatePublication = DateTime.Parse("20/09/2021 15:16") },
                });

                myDbContext.SaveChanges();

                Console.WriteLine("\nInit. des data de la base réalisée.\n");

            }
        }

        private static bool estBaseVierge()
        {
            return !myDbContext.Bibliotheques.Any();
        }



        //----------------------------------------------------

        private static void ShowData(object data)
        {
            Console.WriteLine(GetSerializedData(data));

        }

        private static string GetSerializedData(object data)
        {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
