using Application.DTOs.Ports.AddPort;

namespace Application.UseCases.Interfaces.Ports
{
    public interface IAddPortUseCase :  IUseCase<AddPortUseCaseRequestDTO, AddPortUseCaseResponseDTO>
    {
    }
}
