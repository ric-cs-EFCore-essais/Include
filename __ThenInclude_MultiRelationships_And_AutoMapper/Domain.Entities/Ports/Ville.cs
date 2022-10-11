using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Ville : AEntity, IEntity
    {
        public string Nom { get; init; }


        public IList<Port> Ports { get; init; } //<< De ce fait, EF créera automatiquement une FK VilleId dans la table Ports

    }
}
