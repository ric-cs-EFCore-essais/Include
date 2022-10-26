using Domain.Entities.Specifications.Interfaces;

using Domain.Entities.Ports;

namespace Domain.Entities.Specifications.Ports
{
    public class VilleWithNameContainingSpecification : ASpecification<Ville>, ISpecification<Ville>
    {
        public VilleWithNameContainingSpecification(string subString) 
            : base((Ville ville) => ville.Nom.ToLower().Contains(subString)) //Conversion auto. du filtre (lambda), en LINQ Expression !
        {
        }
    }
}
