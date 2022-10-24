
using System.Collections.Generic;

namespace Application.DTOs.Ports.GetPort
{
    public record GetPortFullDataUseCaseResponseDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string NomVille { get; set; }

        //IList<BateauDTO> Bateaux { get; }


    }
}
