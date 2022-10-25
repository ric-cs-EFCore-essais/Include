using Domain.UnitsOfWork.Interfaces.Ports;
using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPort;

namespace Application.UseCases.Ports.GetPort
{
    public class GetPortMinimalDataUseCase: APortsUseCase<GetPortMinimalDataUseCaseRequestDTO, GetPortMinimalDataUseCaseResponseDTO>, IGetPortMinimalDataUseCase
    {
        public GetPortMinimalDataUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override GetPortMinimalDataUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, GetPortMinimalDataUseCaseRequestDTO requestDTO)
        {
            int portId = requestDTO.PortId;
            Port port = portsUnitOfWork.PortRepository.Get(portId);

            GetPortMinimalDataUseCaseResponseDTO retour = portsDTOsMapper.Map<Port, GetPortMinimalDataUseCaseResponseDTO>(port);
            return retour;
        }
    }
}
