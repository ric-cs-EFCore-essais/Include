using Domain.UnitsOfWork.Interfaces.Ports;
using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPort;

namespace Application.UseCases.Ports.GetPort
{
    public class GetPortMinimalDataUseCase: IGetPortMinimalDataUseCase
    {
        private readonly IPortsUnitOfWorkFactory portsUnitOfWorkFactory;
        private readonly IPortsDTOsMapper portsDTOsMapper;

        public GetPortMinimalDataUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper)
        {
            this.portsUnitOfWorkFactory = portsUnitOfWorkFactory;
            this.portsDTOsMapper = portsDTOsMapper;
        }

        public GetPortMinimalDataUseCaseResponseDTO Execute(GetPortMinimalDataUseCaseRequestDTO requestDTO)
        {
            GetPortMinimalDataUseCaseResponseDTO retour = null;

            using (IPortsUnitOfWork portsUnitOfWork = portsUnitOfWorkFactory.GetInstance())
            {
                int portId = requestDTO.PortId;
                Port port = portsUnitOfWork.PortRepository.Get(portId);

                retour = portsDTOsMapper.Map<Port, GetPortMinimalDataUseCaseResponseDTO>(port);
            }

            return retour;
        }
    }
}
