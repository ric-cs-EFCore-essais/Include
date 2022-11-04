namespace Domain.Entities.Ports
{
    public class CapitaineDiplome : AEntity
    {
        public int CapitaineId { get; init; }
        public Capitaine Capitaine { get; init; }

        public int DiplomeId { get; init; }
        public Diplome Diplome { get; init; }

        public uint AnneeObtention { get; init; }
    }
}
