using Domain.Entities.Interfaces;

namespace Domain.Entities.Ports
{
    public class Ancre : AEntity, IEntity
    {
        public uint? Poids { get; init; }

    }
}
