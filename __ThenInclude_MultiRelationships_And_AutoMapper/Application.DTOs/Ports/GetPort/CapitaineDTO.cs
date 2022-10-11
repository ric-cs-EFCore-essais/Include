using System.Collections.Generic;

namespace Application.DTOs.Ports.GetPort
{
    internal record CapitaineDTO
    {
        public int Id { get; }

        public string Nom { get; }

        public IList<DiplomeDTO> Diplomes { get; }
    }
}
