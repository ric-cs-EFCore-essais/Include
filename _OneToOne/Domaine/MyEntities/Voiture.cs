namespace Domaine.MyEntities
{
    public class Voiture
    {
        //Rappel : sur une entité, un membre de type long ou int(et non uint), ayant pour Nom "Id" ou bien "[NomDeLaClasse][Id]" sera automatiquement considéré par EF,
        //         comme étant la PK auto-incr. (Identity) de cette classe.
        public int Id { get; set; }

        public string Model { get; set; }
    }
}
