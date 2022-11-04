using System.Collections.Generic;

namespace Domain.Entities.Ports
{
    public class Ville : AEntity
    {
        public string Nom { get; init; }


        public IList<Port> Ports { get; set; } //<< De ce fait, EF créera automatiquement une FK VilleId dans la table Ports

    }
}
