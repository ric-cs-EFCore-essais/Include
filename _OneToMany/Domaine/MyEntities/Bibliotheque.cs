using System.Collections.Generic;

#pragma warning disable S125 // Sections of code should not be commented out
namespace Domaine.MyEntities
{
    public class Bibliotheque //Le simple fait que la présente classe ait pour membre une List de Livre, fait qu'EF va détecter qu'il faut :
    {                         // - créer dans la table Livres, une FK ( int, nullable :/ ) de nom : BibliothequeId   (SonNomParDefaut = NomPrésenteClasse+NomDeSaPK)
                              //   ceci sans avoir besoin d'ajouter quoique ce soit à la classe Livre !     
                              // PAR CONTRE :
                              //  - Si je veux dans le code pouvoir me servir de ce champ BibliothequeId, il devient plus pratique de l'ajouter
                              //    à ma classe Livre (ce que j'ai fait ici exprès).
                              //  - et/ou Si je veux que ce champ BibliothequeId soit non nullable (nullable par défaut) : il me faut l'ajouter explicitement
                              //    dans la classe Livre, puis (dans LivreConfig) faire un
                              //      entityModelBuilder.Property(livre => livre.BibliothequeId).IsRequired();
                              //    (ce que j'ai fait ici expressément).


        //Rappel : sur une entité, un membre de type long ou int(et non uint), ayant pour Nom "Id" ou bien "[NomDeLaClasse][Id]" sera automatiquement considéré par EF,
        //         comme étant la PK auto-incr. (Identity) de cette classe.        
        public int Id { get; set; }

        public string Nom { get; set; }


        public IList<Livre> Livres { get; set; } // <<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
#pragma warning restore S125 // Sections of code should not be commented out

