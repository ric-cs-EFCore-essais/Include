using System.Collections.Generic;

namespace Domain.Entities.Ports
{
    public class Capitaine : AEntity
    {
        public string Nom { get; init; }

        public IList<CapitaineDiplome> CapitainesDiplomes { get; set;  }  // Pour la relation Many to Many (Capitaine / Diplome)
                                                                   // Laquelle relation fera qu'EF créera automatiquement une table
                                                                   // de liaison de nom : CapitaineDiplome
                                                                   //Ce Membre Liste est également à mettre dans l'entité Diplome.
    }
}
