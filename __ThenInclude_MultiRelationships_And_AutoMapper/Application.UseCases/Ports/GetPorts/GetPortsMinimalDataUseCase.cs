using Application.DTOs.Ports.GetPorts;
using Application.UseCases.Interfaces.Ports;

namespace Application.UseCases.Ports.GetPorts
{
    public class GetPortsMinimalDataUseCase : IGetPortsMinimalDataUseCase
    {
        public GetPortsMinimalDataUseCase()
        {

        }

        public GetPortsMinimalDataUseCaseResponseDTO Execute(GetPortsMinimalDataUseCaseRequestDTO requestDTO)
        {
            var retour = new GetPortsMinimalDataUseCaseResponseDTO();
            return retour;

        }
    }
}
