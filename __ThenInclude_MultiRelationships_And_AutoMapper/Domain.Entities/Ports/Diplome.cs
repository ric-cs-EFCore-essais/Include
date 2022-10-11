using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Diplome : AEntity, IEntity
    {
        public string Intitule { get; init; }

        public IList<CapitaineDiplome> CapitainesDiplomes;
    }
}
