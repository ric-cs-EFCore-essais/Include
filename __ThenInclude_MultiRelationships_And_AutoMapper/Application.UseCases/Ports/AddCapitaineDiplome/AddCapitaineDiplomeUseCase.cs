using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddCapitaineDiplome;

namespace Application.UseCases.Ports.AddCapitaineDiplome
{
    public class AddCapitaineDiplomeUseCase : APortsUseCase<AddCapitaineDiplomeUseCaseRequestDTO, AddCapitaineDiplomeUseCaseResponseDTO>, IAddCapitaineDiplomeUseCase
    {
        public AddCapitaineDiplomeUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddCapitaineDiplomeUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddCapitaineDiplomeUseCaseRequestDTO requestDTO)
        {
            CapitaineDiplome capitaineDiplome = portsDTOsMapper.Map<AddCapitaineDiplomeUseCaseRequestDTO, CapitaineDiplome>(requestDTO);

            portsUnitOfWork.CapitaineDiplomeRepository.Add(capitaineDiplome);
            portsUnitOfWork.Commit();

            AddCapitaineDiplomeUseCaseResponseDTO retour = portsDTOsMapper.Map<CapitaineDiplome, AddCapitaineDiplomeUseCaseResponseDTO>(capitaineDiplome);
            return retour;
        }
    }

}
