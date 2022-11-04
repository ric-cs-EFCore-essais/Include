using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddCapitaine;

namespace Application.UseCases.Ports.AddCapitaine
{
    public class AddCapitaineUseCase : APortsUseCase<AddCapitaineUseCaseRequestDTO, AddCapitaineUseCaseResponseDTO>, IAddCapitaineUseCase
    {
        public AddCapitaineUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddCapitaineUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddCapitaineUseCaseRequestDTO requestDTO)
        {
            Capitaine capitaine = portsDTOsMapper.Map<AddCapitaineUseCaseRequestDTO, Capitaine>(requestDTO);

            portsUnitOfWork.CapitaineRepository.Add(capitaine);
            portsUnitOfWork.Commit();

            AddCapitaineUseCaseResponseDTO retour = portsDTOsMapper.Map<Capitaine, AddCapitaineUseCaseResponseDTO>(capitaine);
            return retour;
        }
    }

}
