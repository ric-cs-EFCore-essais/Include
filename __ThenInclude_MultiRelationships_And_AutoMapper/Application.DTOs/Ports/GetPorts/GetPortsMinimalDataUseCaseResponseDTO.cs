using System.Collections.Generic;

using Application.DTOs.Ports.GetPort;

namespace Application.DTOs.Ports.GetPorts
{
    public record GetPortsMinimalDataUseCaseResponseDTO
    {
        public IList<GetPortMinimalDataUseCaseResponseDTO> Ports { get; }
    }
}
