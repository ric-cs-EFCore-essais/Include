
namespace Application.DTOs.Ports
{
    public record BateauDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public uint PoidsAncre { get; set; }

        public CapitaineDTO Capitaine { get; set; }
    }
}
