using System.Collections.Generic;

//using Application.DTOs.Ports.GetPort;

namespace Application.DTOs.Ports.GetPorts
{
    public record GetPortsMinimalDataUseCaseResponseDTO
    {
        //public IList<GetPortMinimalDataUseCaseResponseDTO> Ports { get; set; }

        public IList<PortMinimalDataForGetPortsMinimalDataUseCaseResponseDTO> Ports { get; set; }

        public int NombrePorts { get; set; }

        public double NombreMoyenBateauxParPort { get; set; }
    }
}
