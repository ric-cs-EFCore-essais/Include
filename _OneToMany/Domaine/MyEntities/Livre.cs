using System;

namespace Domaine.MyEntities
{
    public class Livre
    {
        //Rappel : sur une entité, un membre de type long ou int(et non uint), ayant pour Nom "Id" ou bien "[NomDeLaClasse][Id]" sera automatiquement considéré par EF,
        //         comme étant la PK auto-incr. (Identity) de cette classe.
        public int Id { get; set; }

        public string Titre { get; set; }

        public DateTime DatePublication { get; set; }



        public int BibliothequeId { get; set; } //Ce membre n'est pas nécessaire pour qu'une FK (vers la table Bibliotheques) soit automatiquement créée
                                                // dans la table Livres (mais je l'ajoute quand même, pour les raisons que j'explicite dans la classe Bibliotheque).

    }
}
