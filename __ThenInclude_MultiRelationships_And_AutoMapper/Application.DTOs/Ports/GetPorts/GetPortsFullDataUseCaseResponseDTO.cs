using System.Collections.Generic;


namespace Application.DTOs.Ports.GetPorts
{
    public record GetPortsFullDataUseCaseResponseDTO
    {
        public IList<PortFullDataForGetPortsFullDataUseCaseResponseDTO> Ports { get; set; }

        public int NombrePorts { get; set; }

        public double NombreMoyenBateauxParPort { get; set; }
    }
}
