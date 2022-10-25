using System.Collections.Generic;

namespace Application.DTOs.Ports
{
    public record CapitaineDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public IList<DiplomeDTO> Diplomes { get; set; }
    }
}
