using System.Collections.Generic;

namespace Application.DTOs.Ports.AddCapitaineDiplome
{
    public record AddCapitaineDiplomesUseCaseRequestDTO
    {
        public int CapitaineId { get; set; }

        public IList<CapitaineDiplomeForAddCapitaineDiplomesUseCaseRequestDTO> Diplomes { get; set; }
    }
}
