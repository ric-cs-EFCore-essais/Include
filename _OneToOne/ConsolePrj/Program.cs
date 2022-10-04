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
        private static int idPlaceDeParking1 = 1;

        static void Main()
        {
            var myDbContextFactory = new MyApplicationDbContextFactory(appelManuel: true);
            myDbContext = myDbContextFactory.GetDbContext();

            PlaceDataIfBaseVierge();

            DisplayVoitures();
            Console.ReadKey();


            DisplayPlacesDeParkingSansDetailVoiture();
            Console.ReadKey();

            DisplayPlacesDeParkingAvecDetailVoiture();
            Console.ReadKey();


            ModifierVoitureDId2();
            Console.ReadKey();

            DisplayVoitures();
            Console.ReadKey();
        }

        private static void ModifierVoitureDId2()
        {
            var idVoitureAModifier = 2;
            Console.WriteLine($"\n\n ----- Modif. Model du Voiture d'id {idVoitureAModifier} ---- \n");

            var VoitureAModifier = myDbContext.Voitures.Find(idVoitureAModifier);
            VoitureAModifier.Model += " modified! ";
            myDbContext.SaveChanges();
        }

        private static void DisplayVoitures()
        {
            Console.WriteLine("\n\n ----- Liste des Voitures ---- \n");

            // .AsNoTracking<Voiture>() ci-dessous sert JUSTE pour ne pas que les Voitures soient mises en cache,
            //    (en effet ma connexion (usage du même DbContext tout du long, reste ouverte tout du long de mon essai))
            //    En effet, si mise en cache il y avait, mon exemple ne serait pas démonstratif, et la liste des Voitures serait déjà chargée
            //    VU QUE ici DisplayVoitures() est appelée en tout premier !
            ShowData(myDbContext.Voitures
                    .AsNoTracking<Voiture>()
                    .ToList()); //pour pouvoir utiliser ToList() sur un DbSet, il m'a fallu faire un : using System.Linq
        }

        private static void DisplayPlacesDeParkingSansDetailVoiture()
        {
            Console.WriteLine("\n\n ----- Liste des PlacesDeParking MAIS sans détail Voiture ---- \n");

            ShowData(myDbContext.PlacesDeParking.ToList()); //pour pouvoir utiliser ToList() sur un DbSet, il m'a fallu faire un : using System.Linq
        }

        private static void DisplayPlacesDeParkingAvecDetailVoiture()
        {
            Console.WriteLine("\n\n ----- Liste des PlacesDeParking AVEC détail Voiture (grâce à l'usage de Include() sur le DbSet ---- \n");
            ShowData(myDbContext.PlacesDeParking.Include(p => p.Voiture).ToList()); //Pour pouvoir utiliser Include() sur le DbSet, il m'a fallu faire un : using Microsoft.EntityFrameworkCore
            //Grâce à Include() dans la requête, EF comprend qu'il doit pour chaque PlaceDeParking traitée,
            // récupérer l'enreg. Voiture qui a pour Id la valeur du champ VoitureId de la dite PlaceDeParking.
            // (Rappel: la classe PlaceDeParking a bien un membre : Voiture (nullable en l'occurence)).
        }

        private static void PlaceDataIfBaseVierge() //Juste pour alimenter une première fois la base, si pas déjà fait.
        {
            if (estBaseVierge())
            {
                var voitures = new[]
                {
                    new Voiture { Model = "Voiture1", /*PlaceDeParkingId = idPlaceDeParking1*/ },
                    new Voiture { Model = "Voiture2", /*PlaceDeParkingId = idPlaceDeParking1*/ },
                    new Voiture { Model = "Voiture3", /*PlaceDeParkingId = idPlaceDeParking2*/ },
                    new Voiture { Model = "Voiture4", /*PlaceDeParkingId = idPlaceDeParking2*/ },
                };

                myDbContext.Voitures.AddRange(voitures);

                myDbContext.PlacesDeParking.AddRange(new[]
                {
                    new PlaceDeParking { Ref="PlaceDeParking 1", Voiture = voitures[0] },
                    new PlaceDeParking { Ref="PlaceDeParking 2", Voiture = voitures[1] },
                    new PlaceDeParking { Ref="PlaceDeParking 3" },
                    new PlaceDeParking { Ref="PlaceDeParking 4", Voiture = voitures[3] },
                });

                myDbContext.SaveChanges();

                Console.WriteLine("\nInit. des data de la base réalisée.\n");

            }
        }

        private static bool estBaseVierge()
        {
            return !myDbContext.PlacesDeParking.Any();
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
