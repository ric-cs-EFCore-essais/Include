using Application.DTOs.Ports.GetPort;

namespace Application.UseCases.Interfaces.Ports
{
    public interface IGetPortUseCase :  IUseCase<GetPortUseCaseRequestDTO, GetPortUseCaseResponseDTO>
    {
    }
}
