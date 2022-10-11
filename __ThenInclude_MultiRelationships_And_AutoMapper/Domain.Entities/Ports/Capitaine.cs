using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Capitaine : AEntity, IEntity
    {
        public string Nom { get; init; }

        public IList<CapitaineDiplome> CapitainesDiplomes;

    }
}
