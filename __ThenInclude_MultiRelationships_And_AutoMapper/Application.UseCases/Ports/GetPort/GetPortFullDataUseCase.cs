using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPort;

namespace Application.UseCases.Ports.GetPort
{
    public class GetPortFullDataUseCase : APortsUseCase<GetPortFullDataUseCaseRequestDTO, GetPortFullDataUseCaseResponseDTO>, IGetPortFullDataUseCase
    {
        public GetPortFullDataUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override GetPortFullDataUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, GetPortFullDataUseCaseRequestDTO requestDTO)
        {
            int portId = requestDTO.PortId;
            Port port = portsUnitOfWork.PortRepository.Get(portId);

            GetPortFullDataUseCaseResponseDTO retour = portsDTOsMapper.Map<Port, GetPortFullDataUseCaseResponseDTO>(port);
            return retour;
        }
    }

}
