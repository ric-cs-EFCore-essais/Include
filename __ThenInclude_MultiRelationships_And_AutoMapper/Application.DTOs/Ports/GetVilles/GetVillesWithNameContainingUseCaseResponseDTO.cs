using System.Collections.Generic;


namespace Application.DTOs.Ports.GetVilles
{
    public record GetVillesWithNameContainingUseCaseResponseDTO
    {
        public IList<VilleDTO> Villes { get; set; }
    }
}
