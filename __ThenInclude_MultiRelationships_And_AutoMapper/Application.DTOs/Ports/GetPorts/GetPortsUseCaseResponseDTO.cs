using System.Collections.Generic;

using Application.DTOs.Ports.GetPort;

namespace Application.DTOs.Ports.GetPorts
{
    public record GetPortsUseCaseResponseDTO
    {
        public IList<GetPortUseCaseResponseDTO> Ports { get; }
    }
}
