using Application.DTOs.Ports.GetPort;

using Application.UseCases.Interfaces.Ports;
using Domain.Entities.Ports;
using Domain.Repositories.Interfaces.Ports;

namespace Application.UseCases.Ports.GetPort
{
    public class GetPortUseCase: IGetPortUseCase
    {
        private readonly IPortRepository portRepository;
        private readonly IVilleRepository villeRepository;

        public GetPortUseCase(
            IPortRepository portRepository,
            IVilleRepository villeRepository
        )
        {
            this.portRepository = portRepository;
            this.villeRepository = villeRepository;
        }

        public GetPortUseCaseResponseDTO Execute(GetPortUseCaseRequestDTO requestDTO)
        {
            var retour = new GetPortUseCaseResponseDTO();

            int portId = requestDTO.PortId;
            Port port = portRepository.Find(portId);
            if (port is not null)
            {
                var ville = villeRepository.FindByPort(portId);
                if (ville is not null)
                {
                    retour.Id = port.Id;
                    retour.Nom = port.Nom;
                    retour.NomVille = ville.Nom;
                }
            }

            return retour;

        }
    }
}
