using System.Collections.Generic;

using Domain.Entities.Ports;

namespace Domain.Repositories.Interfaces.Ports
{
    public interface IVilleRepository : IRepository<Ville>
    {
        Ville GetByPort(int portId);

        IEnumerable<Ville> GetWithNameContaining(string subString);
    }
}
