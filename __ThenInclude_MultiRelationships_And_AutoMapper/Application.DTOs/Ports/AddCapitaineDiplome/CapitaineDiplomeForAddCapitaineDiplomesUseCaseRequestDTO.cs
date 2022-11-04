namespace Application.DTOs.Ports.AddCapitaineDiplome
{
    public record CapitaineDiplomeForAddCapitaineDiplomesUseCaseRequestDTO
    {
        public int DiplomeId { get; set; }

        public uint AnneeObtention { get; set; }
    }
}
