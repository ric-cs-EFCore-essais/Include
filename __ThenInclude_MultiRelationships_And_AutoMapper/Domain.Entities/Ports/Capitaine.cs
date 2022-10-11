using System.Collections.Generic;

using Domain.Entities.Interfaces;


namespace Domain.Entities.Ports
{
    public class Capitaine : AEntity, IEntity
    {
        public string Nom { get; init; }

        public IList<CapitaineDiplome> CapitainesDiplomes; // Pour la relation Many to Many (Capitaine / Diplome)
                                                           // Laquelle relation fera qu'EF créera automatiquement une table
                                                           // de liaison de nom : CapitaineDiplome
    }
}
