using System.Collections.Generic;

using Domain.Entities.Extensions;

using Domain.Entities.Ports;

namespace Tests.FakeData.Ports
{
    public static class PortsFakeData
    {
        public static List<Ville> GetVilles(bool withIds = false)
        {
            var retours = new List<Ville>
            {
                new Ville
                {
                    Nom = "Marseille",
                },

                new Ville
                {
                    Nom = "La Rochelle",
                },

                new Ville
                {
                    Nom = "Lisieux",
                },

                new Ville
                {
                    Nom = "Fréjus",
                },

                new Ville
                {
                    Nom = "Cannes",
                },

                new Ville
                {
                    Nom = "Nice",
                },

                new Ville
                {
                    Nom = "Gibraltar",
                },

                new Ville
                {
                    Nom = "Miami",
                },

            };

            if (withIds)
            {
                retours = retours.WithIds<Ville>(1);
            }

            return retours;
        }

        public static List<Port> GetPorts(bool withIds = false)
        {
            var retours = new List<Port>
            {
                new Port
                {
                    Nom = "Port 3A",
                    VilleId = 3,
                },

                new Port
                {
                    Nom = "Port 4A",
                    VilleId = 4,
                },

                new Port
                {
                    Nom = "Port 4B",
                    VilleId = 4,
                },

                new Port
                {
                    Nom = "Port 3B",
                    VilleId = 3,
                },

                new Port
                {
                    Nom = "Port 5A",
                    VilleId = 5,
                },

                new Port
                {
                    Nom = "Port 5B",
                    VilleId = 5,
                },

                new Port
                {
                    Nom = "Port 6A",
                    VilleId = 6,
                },

                new Port
                {
                    Nom = "Port 6B",
                    VilleId = 6,
                },

                new Port
                {
                    Nom = "Port 1A",
                    VilleId = 1,
                },
                new Port
                {
                    Nom = "Port 1B",
                    VilleId = 1,
                },
            };

            if (withIds)
            {
                retours = retours.WithIds<Port>(1);
            }

            return retours;
        }

        public static List<Ancre> GetAncres(bool withIds = false)
        {
            var retours = new List<Ancre>
            {
                new Ancre
                {
                    Poids = 120,
                },

                new Ancre
                {
                    Poids = 121,
                },

                new Ancre
                {
                    Poids = 122,                
                },

                new Ancre
                {
                    Poids = 123, 
                },

                new Ancre
                {
                    Poids = 124,                
                },

                new Ancre
                {
                    Poids = 125,  
                },

                new Ancre
                {
                    Poids = 126,                
                },

                new Ancre
                {
                    Poids = 127,
                },

                new Ancre
                {
                    Poids = 128,
                },

                new Ancre
                {
                    Poids = 129,
                },

                new Ancre
                {
                    Poids = 130,
                },

                new Ancre
                {
                    Poids = 131,
                },

                new Ancre
                {
                    Poids = 132,
                },

                new Ancre
                {
                    Poids = 133,
                },

                new Ancre
                {
                    Poids = 134,
                },

                new Ancre
                {
                    Poids = 135,
                },

            };

            if (withIds)
            {
                retours = retours.WithIds<Ancre>(1);
            }

            return retours;
        }

        public static List<Capitaine> GetCapitaines(bool withIds = false)
        {
            var retours = new List<Capitaine>
            {
                new Capitaine
                {
                    Nom = "POURJIN",
                },

                new Capitaine
                {
                    Nom = "MURLOCK",
                },

                new Capitaine
                {
                    Nom = "LIDIAN",
                },

                new Capitaine
                {
                    Nom = "BRAQUEMART",
                },

                new Capitaine
                {
                    Nom = "CHANCELLE",
                },

                new Capitaine
                {
                    Nom = "BURNETTE",
                },

                new Capitaine
                {
                    Nom = "MELCOL",
                },

            };

            if (withIds)
            {
                retours = retours.WithIds<Capitaine>(1);
            }

            return retours;
        }

        public static List<Diplome> GetDiplomes(bool withIds = false)
        {
            var retours = new List<Diplome>
            {
                new Diplome
                {
                    Intitule = "LICENCE",
                },

                new Diplome
                {
                    Intitule = "MASTER",
                },

                new Diplome
                {
                    Intitule = "BAC",
                },

                new Diplome
                {
                    Intitule = "BTS",
                },

                new Diplome
                {
                    Intitule = "CAP",
                },

                new Diplome
                {
                    Intitule = "DUT",
                },

                new Diplome
                {
                    Intitule = "DOCTORAT",
                },

            };

            if (withIds)
            {
                retours = retours.WithIds<Diplome>(1);
            }

            return retours;
        }


        public static List<CapitaineDiplome> GetCapitainesDiplomes(bool withIds = false)
        {
            var retours = new List<CapitaineDiplome>
            {
                new CapitaineDiplome
                {
                    CapitaineId = 1,
                    DiplomeId = 2,
                    AnneeObtention = 1998,
                },

                new CapitaineDiplome
                {
                    CapitaineId = 1,
                    DiplomeId = 3,
                    AnneeObtention = 2006,
                },

                new CapitaineDiplome
                {
                    CapitaineId = 2,
                    DiplomeId = 4,
                    AnneeObtention = 2001,
                },

                new CapitaineDiplome
                {
                    CapitaineId = 3,
                    DiplomeId = 3,
                    AnneeObtention = 1994,
                },

                new CapitaineDiplome
                {
                    CapitaineId = 4,
                    DiplomeId = 1,
                    AnneeObtention = 2010,
                },

                new CapitaineDiplome
                {
                    CapitaineId = 4,
                    DiplomeId = 5,
                    AnneeObtention = 1997,
                },

            };

            if (withIds)
            {
                retours = retours.WithIds<CapitaineDiplome>(1);
            }

            return retours;
        }

        public static List<Bateau> GetBateaux(bool withIds = false)
        {
            var retours = new List<Bateau>
            {
                new Bateau
                {
                    Nom = "B10 - BERKLIN",
                    CapitaineId = 1,
                    PortId = 2,
                    AncreId = 3,
                },

                new Bateau
                {
                    Nom = "B11 - VAUCLERC",
                    CapitaineId = 3,
                    PortId = 2,
                    AncreId = 1,
                },

                new Bateau
                {
                    Nom = "B12 - MERKAL",
                    CapitaineId = 2,
                    PortId = 2,
                    AncreId = 2,
                },

                new Bateau
                {
                    Nom = "B20 - SBEAMAC",
                    CapitaineId = 1,
                    PortId = 4,
                    AncreId = 5,
                },

                new Bateau
                {
                    Nom = "B21 - MERX",
                    CapitaineId = 5,
                    PortId = 4,
                    AncreId = 4,
                },

                new Bateau
                {
                    Nom = "B22 - JONCAO",
                    CapitaineId = 4,
                    PortId = 4,
                    AncreId = 6,
                },

                new Bateau
                {
                    Nom = "C20 - BONJO",
                    CapitaineId = 3,
                    PortId = 3,
                    AncreId = 7,
                },

                new Bateau
                {
                    Nom = "C21 - MILORD",
                    CapitaineId = 5,
                    PortId = 3,
                    AncreId = 8,
                },

                new Bateau
                {
                    Nom = "C22 - BERGSON",
                    CapitaineId = 1,
                    PortId = 3,
                    AncreId = 9,
                },

            };

            if (withIds)
            {
                retours = retours.WithIds<Bateau>(1);
            }

            return retours;
        }

    }
}
