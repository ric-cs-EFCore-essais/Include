using Domain.Entities.Interfaces;

namespace Domain.Entities.Ports
{
    public class Bateau : AEntity, IEntity
    {
        public string Nom { get; init; }


        //public Ancre Ancre { get; init; }
        //public Capitaine Capitaine { get; init; }


    }
}
