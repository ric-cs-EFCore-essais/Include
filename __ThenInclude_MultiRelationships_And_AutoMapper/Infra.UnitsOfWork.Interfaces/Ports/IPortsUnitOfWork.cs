using Domain.Repositories.Interfaces.Ports;

namespace Infra.UnitsOfWork.Interfaces.Ports
{
    public interface IPortsUnitOfWork: IUnitOfWork
    {
        IPortRepository PortRepository { get; init; }
        IVilleRepository VilleRepository { get; init; }
        IAncreRepository AncreRepository { get; init; }
        IDiplomeRepository DiplomeRepository { get; init; }
        ICapitaineRepository CapitaineRepository { get; init; }
        ICapitaineDiplomeRepository CapitaineDiplomeRepository { get; init; }
        IBateauRepository BateauRepository { get; init; }
    }
}