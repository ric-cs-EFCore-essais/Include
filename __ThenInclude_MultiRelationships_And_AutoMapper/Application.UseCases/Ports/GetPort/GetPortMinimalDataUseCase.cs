using Domain.UnitsOfWork.Interfaces.Ports;
using Application.UseCases.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPort;


namespace Application.UseCases.Ports.GetPort
{
    public class GetPortMinimalDataUseCase: IGetPortMinimalDataUseCase
    {
        private readonly IPortsUnitOfWorkFactory portsUnitOfWorkFactory;

        public GetPortMinimalDataUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory)
        {
            this.portsUnitOfWorkFactory = portsUnitOfWorkFactory;
        }

        public GetPortMinimalDataUseCaseResponseDTO Execute(GetPortMinimalDataUseCaseRequestDTO requestDTO)
        {
            var retour = new GetPortMinimalDataUseCaseResponseDTO();

            using (IPortsUnitOfWork portsUnitOfWork = portsUnitOfWorkFactory.GetInstance())
            {

                int portId = requestDTO.PortId;
                Port port = portsUnitOfWork.PortRepository.Get(portId);
                if (port is not null)
                {
                    var ville = portsUnitOfWork.VilleRepository.GetByPort(portId);
                    if (ville is not null)
                    {
                        retour.Id = port.Id;
                        retour.Nom = port.Nom;
                        retour.NomVille = ville.Nom;
                    }
                }
            }

            return retour;
        }
    }
}
