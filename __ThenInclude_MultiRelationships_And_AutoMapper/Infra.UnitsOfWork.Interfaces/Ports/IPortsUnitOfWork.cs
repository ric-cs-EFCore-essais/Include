using Domain.Repositories.Interfaces.Ports;

namespace Infra.UnitsOfWork.Interfaces.Ports
{
    public interface IPortsUnitOfWork: IUnitOfWork
    {
        IPortRepository PortRepository { get; init; }
        IVilleRepository VilleRepository { get; init; }
    }
}