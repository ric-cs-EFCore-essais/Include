
namespace Application.DTOs.Ports.AddPort
{
    public record AddPortUseCaseRequestDTO
    {
        public string Nom { get; set; }

        public int VilleId { get; set; }
    }
}
