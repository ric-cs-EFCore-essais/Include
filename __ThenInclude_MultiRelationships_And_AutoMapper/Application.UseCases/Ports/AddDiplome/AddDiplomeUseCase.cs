using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddDiplome;

namespace Application.UseCases.Ports.AddDiplome
{
    public class AddDiplomeUseCase : APortsUseCase<AddDiplomeUseCaseRequestDTO, AddDiplomeUseCaseResponseDTO>, IAddDiplomeUseCase
    {
        public AddDiplomeUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddDiplomeUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddDiplomeUseCaseRequestDTO requestDTO)
        {
            Diplome diplome = portsDTOsMapper.Map<AddDiplomeUseCaseRequestDTO, Diplome>(requestDTO);

            portsUnitOfWork.DiplomeRepository.Add(diplome);
            portsUnitOfWork.Commit();

            AddDiplomeUseCaseResponseDTO retour = portsDTOsMapper.Map<Diplome, AddDiplomeUseCaseResponseDTO>(diplome);
            return retour;
        }
    }

}
