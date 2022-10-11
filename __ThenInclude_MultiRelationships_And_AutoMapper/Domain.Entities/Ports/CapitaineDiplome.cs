using Domain.Entities.Interfaces;

namespace Domain.Entities.Ports
{
    public class CapitaineDiplome : AEntity, IEntity
    {
        public int CapitaineId { get; init; }
        public Capitaine Capitaine { get; init; }

        public int DiplomeId { get; init; }
        public Diplome Diplome { get; init; }

        public uint AnneeObtention { get; init; }
    }
}
