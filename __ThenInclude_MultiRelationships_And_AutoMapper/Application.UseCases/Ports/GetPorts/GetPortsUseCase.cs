using Application.DTOs.Ports.GetPorts;
using Application.UseCases.Interfaces.Ports;

namespace Application.UseCases.Ports.GetPorts
{
    public class GetPortsUseCase : IGetPortsUseCase
    {
        public GetPortsUseCase()
        {

        }

        public GetPortsUseCaseResponseDTO Execute(GetPortsUseCaseRequestDTO requestDTO)
        {
            var retour = new GetPortsUseCaseResponseDTO();
            return retour;

        }
    }
}
