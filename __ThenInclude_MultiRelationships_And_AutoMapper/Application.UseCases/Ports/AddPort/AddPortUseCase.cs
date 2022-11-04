using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddPort;

namespace Application.UseCases.Ports.AddPort
{
    public class AddPortUseCase : APortsUseCase<AddPortUseCaseRequestDTO, AddPortUseCaseResponseDTO>, IAddPortUseCase
    {
        public AddPortUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddPortUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddPortUseCaseRequestDTO requestDTO)
        {
            Port port = portsDTOsMapper.Map<AddPortUseCaseRequestDTO, Port>(requestDTO);

            portsUnitOfWork.PortRepository.Add(port);
            portsUnitOfWork.Commit();

            AddPortUseCaseResponseDTO retour = portsDTOsMapper.Map<Port, AddPortUseCaseResponseDTO>(port);
            return retour;
        }
    }

}
