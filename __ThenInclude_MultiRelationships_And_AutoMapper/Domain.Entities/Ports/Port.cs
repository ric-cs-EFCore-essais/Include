using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Port : AEntity, IEntity
    {
        public string Nom { get; init; }


        public IList<Bateau> Bateaux { get; init; }

    }
}
