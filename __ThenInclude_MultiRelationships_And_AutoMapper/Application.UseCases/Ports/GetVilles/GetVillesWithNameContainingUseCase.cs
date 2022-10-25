using System;
using System.Collections.Generic;

using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetVilles;

namespace Application.UseCases.Ports.GetVilles
{
    public class GetVillesWithNameContainingUseCase : APortsUseCase<GetVillesWithNameContainingUseCaseRequestDTO, GetVillesWithNameContainingUseCaseResponseDTO>, IGetVillesWithNameContainingUseCase
    {
        public GetVillesWithNameContainingUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper)
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override GetVillesWithNameContainingUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, GetVillesWithNameContainingUseCaseRequestDTO requestDTO)
        {
            var villeNameSubString = requestDTO.SubString;

            List<Ville> filteredVilles = portsUnitOfWork.VilleRepository.GetWithNameContaining(villeNameSubString) as List<Ville>;

            GetVillesWithNameContainingUseCaseResponseDTO retour = portsDTOsMapper.Map<List<Ville>, GetVillesWithNameContainingUseCaseResponseDTO>(filteredVilles);
            return retour;
        }
    }

}