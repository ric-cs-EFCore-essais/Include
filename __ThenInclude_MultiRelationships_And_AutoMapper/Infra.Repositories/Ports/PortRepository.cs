using System.Collections.Generic;
using System.Linq;

using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;
using Infra.DataSet.Interfaces;

using Domain.Entities.Ports;

namespace Infra.Repositories.Ports
{
    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IDataSet<Port> GetDataSet()
        {
            return dataContext.Ports;
        }

        public override Port Get(int id)
        {
            var retour = 
                //IncludingBateaux(GetEntitiesAsQueryable())
                IncludingBateauxSimplifiedOptimized(GetEntitiesAsQueryable()) //<<< Cette façon de faire est bien plus rapide que celle du-dessus !
                                                                              // car notamment, je ne fais pas de ToList() ou ElementAt(0) ici et là
                                                                              // Différence :  3-5ms   vs   35-40ms !!
                .SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public override IEnumerable<Port> GetAll()
        {
            var retour =
                //IncludingBateaux(GetEntitiesAsQueryable())
                IncludingBateauxSimplifiedOptimized(GetEntitiesAsQueryable()) //<<< plus rapide que via IncludingBateaux(...)
                                                                              // Différence :  3-5ms   vs   25-35ms !!
                .ToList();
            return retour;
        }

        private IQueryable<Port> IncludingBateaux(IQueryable<Port> portsQuery) //Requête NON optimale
        {
            var retour = portsQuery.GroupJoin(dataContext.Bateaux.Entities,
                    port => port.Id,
                    bateau => bateau.PortId,
                    (port, bateaux) => new Port
                    {
                        Id = port.Id,
                        Nom = port.Nom,
                        
                        VilleId = port.VilleId,
                        Ville = new List<Port> { port }.AsQueryable().Join(dataContext.Villes.Entities,
                            port => port.VilleId,
                            ville => ville.Id,
                            (port, ville) => new Ville
                            {
                                Id = ville.Id,
                                Nom = ville.Nom
                            }
                        ).ElementAt(0), //Ville du Port

                        Bateaux = bateaux.Join(dataContext.Ancres.Entities,
                            bateau => bateau.AncreId,
                            ancre => ancre.Id,
                            (bateau, ancre) => new Bateau //Pour 1 Bateau
                            {
                                Id = bateau.Id,
                                PortId = bateau.PortId,
                                Nom = bateau.Nom,
                                AncreId = bateau.AncreId,
                                Ancre = ancre,

                                CapitaineId = bateau.CapitaineId,
                                Capitaine = new List<Bateau>{ bateau }.AsQueryable() .Join(dataContext.Capitaines.Entities,
                                    bateau => bateau.CapitaineId,
                                    capitaine => capitaine.Id,
                                    (bateau, capitaine) => new Capitaine
                                    {
                                        Id = capitaine.Id,
                                        Nom = capitaine.Nom,
                                        CapitainesDiplomes = new List<Capitaine> { capitaine }.AsQueryable().Join(dataContext.CapitainesDiplomes.Entities,
                                            capitaine => capitaine.Id,
                                            capitainesDiplomes => capitainesDiplomes.CapitaineId,
                                            (capitaine, capitaineDiplome) => new CapitaineDiplome
                                            {
                                                Id = capitaineDiplome.Id,
                                                AnneeObtention = capitaineDiplome.AnneeObtention,
                                                DiplomeId = capitaineDiplome.DiplomeId,
                                                Diplome = new List<CapitaineDiplome> { capitaineDiplome }.AsQueryable().Join(dataContext.Diplomes.Entities,
                                                    capitaineDiplome => capitaineDiplome.DiplomeId,
                                                    diplome => diplome.Id,
                                                    (capitaineDiplome, diplome) => new Diplome
                                                    {
                                                        Id = diplome.Id,
                                                        Intitule = diplome.Intitule
                                                    }
                                                ).ElementAt(0) //Chaque Diplome du Capitaine

                                            }
                                        ).ToList() //Liste de CapitaineDiplome du Capitaine
                                    }

                                ).ElementAt(0) //Le Capitaine du Bateau
                            }
                        
                        ).ToList() //Liste de Bateau du Port

                    }
                )
                ;
            return retour;
        }

        private IQueryable<Port> IncludingBateauxSimplifiedOptimized(IQueryable<Port> portsQuery)
        {
            var retour = portsQuery
                .Join(dataContext.Villes.Entities,
                    port => port.VilleId,
                    ville => ville.Id,
                    (port, ville) => new //Port et Ville
                    {
                        Port = port,
                        Ville = ville
                    }

                ).GroupJoin(dataContext.Bateaux.Entities,
                    portEtVille => portEtVille.Port.Id,
                    bateau => bateau.PortId,
                    (portEtVille, bateaux) => new //bateaux : liste des Bateau du Port en question
                    {
                        PortEtVille = portEtVille,
                        Bateaux = bateaux
                                    .Join(dataContext.Ancres.Entities,
                                        bateau => bateau.AncreId,
                                        ancre => ancre.Id,
                                        (bateau, ancre) => new //Bateau et Ancre
                                        {
                                            Bateau = bateau,
                                            Ancre = ancre
                                        }
                                    )
                                    .Join(dataContext.Capitaines.Entities,
                                        bateauEtAncre => bateauEtAncre.Bateau.CapitaineId,
                                        capitaine => capitaine.Id,
                                        (bateauEtAncre, capitaine) => new //Bateau et Ancre ET Capitaine
                                        {
                                            BateauEtAncre = bateauEtAncre,
                                            Capitaine = capitaine
                                        }
                                    )
                                    .GroupJoin(dataContext.CapitainesDiplomes.Entities,
                                        bateauEtAncreEtCapitaine => bateauEtAncreEtCapitaine.Capitaine.Id,
                                        capitaineDiplome => capitaineDiplome.CapitaineId,
                                        (bateauEtAncreEtCapitaine, capitaineDiplomes) => new //capitaineDiplomes : liste des CapitaineDiplome du Capitaine du Bateau en question
                                        {
                                            BateauEtAncreEtCapitaine = bateauEtAncreEtCapitaine,
                                            CapitaineDiplomes = capitaineDiplomes
                                                                    .Join(dataContext.Diplomes.Entities,
                                                                        capitaineDiplome => capitaineDiplome.DiplomeId,
                                                                        diplome => diplome.Id,
                                                                        (capitaineDiplome, diplome) => new
                                                                        {
                                                                            CapitaineDiplome = capitaineDiplome,
                                                                            DiplomeIntitule = diplome.Intitule
                                                                        }
                                                                    )
                                        }
                                    )
                    }

                )
                .Select(result => new Port
                    {
                        Id = result.PortEtVille.Port.Id,
                        Nom = result.PortEtVille.Port.Nom,

                        VilleId = result.PortEtVille.Ville.Id,
                        Ville = result.PortEtVille.Ville,

                        Bateaux = result.Bateaux.Select(element => new Bateau
                        {
                            PortId = element.BateauEtAncreEtCapitaine.BateauEtAncre.Bateau.PortId,

                            Id = element.BateauEtAncreEtCapitaine.BateauEtAncre.Bateau.Id,
                            Nom = element.BateauEtAncreEtCapitaine.BateauEtAncre.Bateau.Nom,

                            AncreId = element.BateauEtAncreEtCapitaine.BateauEtAncre.Ancre.Id,
                            Ancre = element.BateauEtAncreEtCapitaine.BateauEtAncre.Ancre,

                            CapitaineId = element.BateauEtAncreEtCapitaine.Capitaine.Id,
                            Capitaine = new Capitaine {
                                Id = element.BateauEtAncreEtCapitaine.Capitaine.Id,
                                Nom = element.BateauEtAncreEtCapitaine.Capitaine.Nom,
                                CapitainesDiplomes =  element.CapitaineDiplomes.Select(capitaineDiplome => new CapitaineDiplome
                                {
                                    Id = capitaineDiplome.CapitaineDiplome.Id,
                                    CapitaineId = capitaineDiplome.CapitaineDiplome.CapitaineId,
                                    Capitaine = null,
                                    DiplomeId = capitaineDiplome.CapitaineDiplome.DiplomeId,
                                    Diplome = new Diplome {
                                        Id = capitaineDiplome.CapitaineDiplome.DiplomeId,
                                        Intitule = capitaineDiplome.DiplomeIntitule
                                    },
                                    AnneeObtention = capitaineDiplome.CapitaineDiplome.AnneeObtention

                                }).ToList()
                            },

                        }).ToList()
                    }
                );

            return retour;
        }

        private IQueryable<Port> GetEntitiesAsQueryable()
        {
            return GetEntities().AsQueryable();
        }

    }
}
