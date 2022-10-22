using Domain.Repositories.Interfaces;
using Domain.Repositories.Interfaces.Ports;
using Infra.DataContext.Interfaces.Ports;

using Domain.Entities.Ports;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories.Ports
{
    public class PortRepository : APortsRepository<Port>, IPortRepository
    {
        public PortRepository(IPortsDataContext dataContext) : base(dataContext)
        {
        }

        protected override IListEnriched<Port> GetEntities()
        {
            return dataContext.Ports.Entities;
        }

        public override Port Get(int id)
        {
            var retour = IncludingBateaux(GetEntitiesAsQueryable()).SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public override IEnumerable<Port> GetAll()
        {
            var retour = IncludingBateaux(GetEntitiesAsQueryable()).ToList();
            return retour;
        }

        private IQueryable<Port> IncludingBateaux(IQueryable<Port> portsQuery)
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

        private IQueryable<Port> GetEntitiesAsQueryable()
        {
            return GetEntities().AsQueryable();
        }

    }
}
