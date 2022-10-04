using System.Collections.Generic;

#pragma warning disable S125 // Sections of code should not be commented out
namespace Domaine.MyEntities
{
    public class PlaceDeParking //Le simple fait que la présente classe ait pour membre une Voiture, fait qu'EF va détecter qu'il faut :
    {                         // - créer dans la table PlacesDeParking, une FK ( int, nullable) de nom : VoitureId   (SonNomParDefaut = TypeMembre+NomDuMembrePKDeCeType)
                              //   ceci sans avoir besoin d'ajouter quoique ce soit à la classe Voiture !
                              // PAR CONTRE : si l'on souhaitait que le champ VoitureId soit NON nullable, il faudrait le déclarer EXPLICITEMENT ici
                              //              comme l'étant ( ... int VoitureId   (et non donc : ...int? VoitureId... )

        //Rappel : sur une entité, un membre de type long ou int(et non uint), ayant pour Nom "Id" ou bien "[NomDeLaClasse][Id]" sera automatiquement considéré par EF,
        //         comme étant la PK auto-incr. (Identity) de cette classe.        
        public int Id { get; set; }

        public string Ref { get; set; }

        //public int VoitureId { get; set; } //<< Pas besoin : SAUF si on veut EXPLICITEMENT stipuler que le champ VoitureId est NON nullable !
        public Voiture Voiture { get; set; }
    }
}
#pragma warning restore S125 // Sections of code should not be commented out

