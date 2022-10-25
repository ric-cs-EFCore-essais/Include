
namespace Application.DTOs.Ports.GetPort
{
    public record GetPortMinimalDataUseCaseResponseDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string NomVille { get; set; }

        public int NombreBateaux { get; set; }

    }
}
