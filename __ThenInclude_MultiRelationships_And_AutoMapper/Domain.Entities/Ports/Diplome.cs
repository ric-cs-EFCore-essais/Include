using System.Collections.Generic;

namespace Domain.Entities.Ports
{
    public class Diplome : AEntity
    {
        public string Intitule { get; init; }

        public IList<CapitaineDiplome> CapitainesDiplomes { get; } // Pour la relation Many to Many (Capitaine / Diplome)
                                                                   // Laquelle relation fera qu'EF créera automatiquement une table
                                                                   // de liaison de nom : CapitaineDiplome
                                                                   //Ce Membre Liste est également à mettre dans l'entité Capitaine.
    }
}
