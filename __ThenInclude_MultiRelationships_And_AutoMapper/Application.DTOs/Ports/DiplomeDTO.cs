
namespace Application.DTOs.Ports
{
    public record DiplomeDTO
    {
        public int Id { get; set; }

        public string Intitule { get; set; }

        public uint AnneeObtention { get; set; }

    }
}
