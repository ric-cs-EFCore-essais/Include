using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddBateau;

namespace Application.UseCases.Ports.AddBateau
{
    public class AddBateauUseCase : APortsUseCase<AddBateauUseCaseRequestDTO, AddBateauUseCaseResponseDTO>, IAddBateauUseCase
    {
        public AddBateauUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddBateauUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddBateauUseCaseRequestDTO requestDTO)
        {
            Bateau bateau = portsDTOsMapper.Map<AddBateauUseCaseRequestDTO, Bateau>(requestDTO);

            portsUnitOfWork.BateauRepository.Add(bateau);
            portsUnitOfWork.Commit();

            AddBateauUseCaseResponseDTO retour = portsDTOsMapper.Map<Bateau, AddBateauUseCaseResponseDTO>(bateau);
            return retour;
        }
    }
}
