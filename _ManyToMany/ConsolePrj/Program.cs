using System;
using System.Linq;

using Microsoft.EntityFrameworkCore; //Pour la méthode Include() d'un DbSet, ainsi que pour la méthode AsNoTracking().

using Transverse.Common.DebugTools;

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

            PlaceDataIfBaseVierge(); //Remplissage ?? && Commenter Config et Entites (table auto : NumeroTirageLoto(concat nom entités)  (Ids: NumerosId, TiragesId  (Nom des membres List))

        }

        private static void PlaceDataIfBaseVierge() //Juste pour alimenter une première fois la base, si pas déjà fait.
        {
            if (estBaseVierge())
            {
                //myDbContext.Numeros.AddRange(new[]
                //{
                //    new Numero { Valeur = 1 },
                //    new Numero { Valeur = 2 },
                //    new Numero { Valeur = 3 },
                //    new Numero { Valeur = 4 },
                //    new Numero { Valeur = 5 },
                //    new Numero { Valeur = 6 },
                //    new Numero { Valeur = 7 },
                //    new Numero { Valeur = 8 },
                //    new Numero { Valeur = 9 },
                //    new Numero { Valeur = 10 },
                //});


                //myDbContext.TiragesLoto.AddRange(new[]
                //{
                //    new TirageLoto { Date = DateTime.Parse("10/08/2014 20:01")},
                //    new TirageLoto { Date = DateTime.Parse("06/03/2004 20:00")},
                //    new TirageLoto { Date = DateTime.Parse("21/08/2016 20:01")},
                //    new TirageLoto { Date = DateTime.Parse("18/02/2017 20:00")},
                //    new TirageLoto { Date = DateTime.Parse("20/03/2006 20:02")},
                //    new TirageLoto { Date = DateTime.Parse("14/06/2011 20:00")},
                //    new TirageLoto { Date = DateTime.Parse("05/01/2022 20:00")},
                //    new TirageLoto { Date = DateTime.Parse("07/09/2010 20:01")},
                //    new TirageLoto { Date = DateTime.Parse("05/07/2003 20:01")},
                //});

                //myDbContext.SaveChanges();


                myDbContext.TiragesLoto.AddRange(new[]
                {
                    new TirageLoto { Date = DateTime.Parse("10/08/2014 20:01"), Numeros = new[] { new Numero() { Valeur = 10 }, new Numero() { Valeur = 8 }, new Numero() { Valeur = 4 } } },
                    new TirageLoto { Date = DateTime.Parse("06/03/2004 20:00"), Numeros = new[] { new Numero() { Valeur = 6 }, new Numero() { Valeur = 3 }, new Numero() { Valeur = 4 } } },
                    new TirageLoto { Date = DateTime.Parse("21/08/2016 20:01"), Numeros = new[] { new Numero() { Valeur = 10 }, new Numero() { Valeur = 8 }, new Numero() { Valeur = 4 } } },
                    new TirageLoto { Date = DateTime.Parse("18/02/2017 20:00"), Numeros = new[] { new Numero() { Valeur = 8 }, new Numero() { Valeur = 2 }, new Numero() { Valeur = 7 } } },
                    new TirageLoto { Date = DateTime.Parse("20/03/2006 20:02"), Numeros = new[] { new Numero() { Valeur = 2 }, new Numero() { Valeur = 3 }, new Numero() { Valeur = 6 } } },
                    new TirageLoto { Date = DateTime.Parse("14/06/2011 20:00"), Numeros = new[] { new Numero() { Valeur = 4 }, new Numero() { Valeur = 6 }, new Numero() { Valeur = 1 } } },
                    new TirageLoto { Date = DateTime.Parse("05/01/2022 20:00"), Numeros = new[] { new Numero() { Valeur = 5 }, new Numero() { Valeur = 1 }, new Numero() { Valeur = 2 } } },
                    new TirageLoto { Date = DateTime.Parse("07/09/2010 20:01"), Numeros = new[] { new Numero() { Valeur = 7 }, new Numero() { Valeur = 9 }, new Numero() { Valeur = 10 } } },
                    new TirageLoto { Date = DateTime.Parse("05/07/2003 20:01"), Numeros = new[] { new Numero() { Valeur = 5 }, new Numero() { Valeur = 7 }, new Numero() { Valeur = 3 } } },
                });
                myDbContext.SaveChanges();

                Console.WriteLine("\nInit. des data de la base réalisée.\n");

            }
        }

        private static bool estBaseVierge()
        {
            return !myDbContext.TiragesLoto.Any();
        }

    }
}
