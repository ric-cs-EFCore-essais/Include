using Domain.Entities.Ports;

namespace Domain.Repositories.Interfaces.Ports
{
    public interface IVilleRepository : IRepository<Ville>
    {
        Ville FindByPort(int portId);
    }
}
