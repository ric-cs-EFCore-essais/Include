namespace Application.DTOs.Ports.AddBateau
{
    public record AddBateauUseCaseRequestDTO
    {
        public string Nom { get; set; }

        public int PortId { get; set; }

        public int AncreId { get; set; }

        public int CapitaineId { get; set; }
    }
}
