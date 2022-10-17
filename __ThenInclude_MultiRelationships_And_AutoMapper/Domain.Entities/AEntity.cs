using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    public abstract class AEntity : IEntity
    {
        public int Id { get; init; }
    }
}
