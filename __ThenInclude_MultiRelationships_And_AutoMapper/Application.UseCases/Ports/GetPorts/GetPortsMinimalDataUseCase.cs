using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPorts;

namespace Application.UseCases.Ports.GetPorts
{
    public class GetPortsMinimalDataUseCase : APortsUseCase<GetPortsMinimalDataUseCaseRequestDTO, GetPortsMinimalDataUseCaseResponseDTO>, IGetPortsMinimalDataUseCase
    {
        public GetPortsMinimalDataUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override GetPortsMinimalDataUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, GetPortsMinimalDataUseCaseRequestDTO requestDTO)
        {
            List<Port> ports = portsUnitOfWork.PortRepository.GetAll() as List<Port>;

            GetPortsMinimalDataUseCaseResponseDTO retour = portsDTOsMapper.Map<List<Port>, GetPortsMinimalDataUseCaseResponseDTO>(ports);
            return retour;
        }
    }

}
