using System.Collections.Generic;
using System.Linq;

using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddCapitaineDiplome;

namespace Application.UseCases.Ports.AddCapitaineDiplome
{
    public class AddCapitaineDiplomesUseCase : APortsUseCase<AddCapitaineDiplomesUseCaseRequestDTO, AddCapitaineDiplomesUseCaseResponseDTO>, IAddCapitaineDiplomesUseCase
    {
        public AddCapitaineDiplomesUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddCapitaineDiplomesUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddCapitaineDiplomesUseCaseRequestDTO requestDTO)
        {
            IList<CapitaineDiplome> capitaineDiplomes = new List<CapitaineDiplome>();
            CapitaineDiplome capitaineDiplome;
            foreach (var diplome in requestDTO.Diplomes)
            {
                capitaineDiplome = portsDTOsMapper.Map<CapitaineDiplomeForAddCapitaineDiplomesUseCaseRequestDTO, CapitaineDiplome>(diplome);
                capitaineDiplome.CapitaineId = requestDTO.CapitaineId;

                capitaineDiplomes.Add(capitaineDiplome);
            }

            //capitaineDiplomes = requestDTO.Diplomes.Select(diplome => new CapitaineDiplome { CapitaineId = requestDTO.CapitaineId, DiplomeId = diplome.DiplomeId, AnneeObtention = diplome.AnneeObtention }).ToList(); //Autre syntaxe pour remplir capitaineDiplomes

            portsUnitOfWork.CapitaineDiplomeRepository.AddRange(capitaineDiplomes);
            portsUnitOfWork.Commit();

            AddCapitaineDiplomesUseCaseResponseDTO retour = new AddCapitaineDiplomesUseCaseResponseDTO();
            return retour;
        }
    }

}
