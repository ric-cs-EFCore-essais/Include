using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Ville : AEntity, IEntity
    {
        public string Nom { get; init; }


        public IList<Port> Ports { get; init; }

    }
}
