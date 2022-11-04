namespace Domain.Entities.Ports
{
    public class Bateau : AEntity
    {
        public string Nom { get; init; }

        public int PortId { get; init; } //Juste pour rendre ce champ obligatoire (c-à-d pas :  int? PortId)


        public int AncreId { get; init; } //Juste pour rendre ce champ obligatoire (c-à-d pas :  int? AncreId)
        public Ancre Ancre { get; init; } //<< De ce fait, EF créera automatiquement une FK AncreId dans la table Bateaux

        public int CapitaineId { get; init; } //Juste pour rendre ce champ obligatoire (c-à-d pas :  int? CapitaineId)
        public Capitaine Capitaine { get; init; } //<< De ce fait, EF créera automatiquement une FK CapitaineId dans la table Bateaux


    }
}
