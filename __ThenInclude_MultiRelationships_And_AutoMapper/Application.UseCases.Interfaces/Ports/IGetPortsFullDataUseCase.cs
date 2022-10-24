using Application.DTOs.Ports.GetPorts;

namespace Application.UseCases.Interfaces.Ports
{
    public interface IGetPortsFullDataUseCase :  IUseCase<GetPortsFullDataUseCaseRequestDTO, GetPortsFullDataUseCaseResponseDTO>
    {
    }
}
