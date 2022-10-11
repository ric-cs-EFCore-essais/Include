
namespace Application.DTOs.Ports.GetPort
{
    internal record BateauDTO
    {
        public int Id { get; }

        public string Nom { get; }

        public uint PoidsAncre { get; }

        public CapitaineDTO Capitaine { get; }
    }
}
