using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Port : AEntity, IEntity
    {
        public string Nom { get; init; }


        public int VilleId { get; init; } //Juste pour rendre ce champ obligatoire (c-à-d pas :  int? VilleId)


        public IList<Bateau> Bateaux { get; init; } //<< De ce fait, EF créera automatiquement une FK PortId dans la table Bateaux

    }
}
