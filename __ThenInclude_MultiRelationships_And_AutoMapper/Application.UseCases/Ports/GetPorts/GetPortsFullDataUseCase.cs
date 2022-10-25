using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPorts;

namespace Application.UseCases.Ports.GetPorts
{
    public class GetPortsFullDataUseCase : APortsUseCase<GetPortsFullDataUseCaseRequestDTO, GetPortsFullDataUseCaseResponseDTO>, IGetPortsFullDataUseCase
    {
        public GetPortsFullDataUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override GetPortsFullDataUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, GetPortsFullDataUseCaseRequestDTO requestDTO)
        {
            List<Port> ports = portsUnitOfWork.PortRepository.GetAll() as List<Port>;

            GetPortsFullDataUseCaseResponseDTO retour = portsDTOsMapper.Map<List<Port>, GetPortsFullDataUseCaseResponseDTO>(ports);
            return retour;
        }
    }

}
