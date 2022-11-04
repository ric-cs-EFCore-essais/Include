using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddAncre;

namespace Application.UseCases.Ports.AddAncre
{
    public class AddAncreUseCase : APortsUseCase<AddAncreUseCaseRequestDTO, AddAncreUseCaseResponseDTO>, IAddAncreUseCase
    {
        public AddAncreUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddAncreUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddAncreUseCaseRequestDTO requestDTO)
        {
            Ancre ancre = portsDTOsMapper.Map<AddAncreUseCaseRequestDTO, Ancre>(requestDTO);

            portsUnitOfWork.AncreRepository.Add(ancre);
            portsUnitOfWork.Commit();

            AddAncreUseCaseResponseDTO retour = portsDTOsMapper.Map<Ancre, AddAncreUseCaseResponseDTO>(ancre);
            return retour;
        }
    }

}
