using System.Collections.Generic;

namespace Application.DTOs.Ports.GetPorts
{
    public record PortFullDataForGetPortsFullDataUseCaseResponseDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public VilleDTO Ville { get; set; }

        public List<BateauDTO> Bateaux { get; set; }


        public int TotalPoidsAncres { get; set; }

    }
}
