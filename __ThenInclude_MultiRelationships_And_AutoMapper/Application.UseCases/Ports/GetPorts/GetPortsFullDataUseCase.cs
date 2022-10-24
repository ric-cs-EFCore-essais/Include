using Application.DTOs.Ports.GetPorts;
using Application.UseCases.Interfaces.Ports;

namespace Application.UseCases.Ports.GetPorts
{
    public class GetPortsFullDataUseCase : IGetPortsFullDataUseCase
    {
        public GetPortsFullDataUseCase()
        {

        }

        public GetPortsFullDataUseCaseResponseDTO Execute(GetPortsFullDataUseCaseRequestDTO requestDTO)
        {
            var retour = new GetPortsFullDataUseCaseResponseDTO();
            return retour;

        }
    }
}
