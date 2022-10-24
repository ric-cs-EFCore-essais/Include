using System.Collections.Generic;

using Application.DTOs.Ports.GetPort;

namespace Application.DTOs.Ports.GetPorts
{
    public record GetPortsFullDataUseCaseResponseDTO
    {
        public IList<GetPortFullDataUseCaseResponseDTO> Ports { get; }
    }
}
