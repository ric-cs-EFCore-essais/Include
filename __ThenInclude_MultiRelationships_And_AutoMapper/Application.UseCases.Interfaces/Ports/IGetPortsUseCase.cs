using Application.DTOs.Ports.GetPorts;

namespace Application.UseCases.Interfaces.Ports
{
    public interface IGetPortsUseCase :  IUseCase<GetPortsUseCaseRequestDTO, GetPortsUseCaseResponseDTO>
    {
    }
}
