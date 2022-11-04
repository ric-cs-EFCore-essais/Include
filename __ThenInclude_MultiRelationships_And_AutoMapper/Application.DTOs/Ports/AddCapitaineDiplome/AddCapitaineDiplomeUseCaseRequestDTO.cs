namespace Application.DTOs.Ports.AddCapitaineDiplome
{
    public record AddCapitaineDiplomeUseCaseRequestDTO
    {
        public int CapitaineId { get; set; }

        public int DiplomeId { get; set; }

        public uint AnneeObtention { get; set; }
    }
}
