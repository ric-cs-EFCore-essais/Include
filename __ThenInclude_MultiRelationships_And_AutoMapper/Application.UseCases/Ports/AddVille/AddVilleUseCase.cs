﻿using Application.UseCases.Interfaces.Ports;
using Application.DTOs.Mappers.Interfaces.Ports;
using Domain.UnitsOfWork.Interfaces.Ports;

using Domain.Entities.Ports;
using Application.DTOs.Ports.AddVille;

namespace Application.UseCases.Ports.AddVille
{
    public class AddVilleUseCase : APortsUseCase<AddVilleUseCaseRequestDTO, AddVilleUseCaseResponseDTO>, IAddVilleUseCase
    {
        public AddVilleUseCase(IPortsUnitOfWorkFactory portsUnitOfWorkFactory, IPortsDTOsMapper portsDTOsMapper) 
            : base(portsUnitOfWorkFactory, portsDTOsMapper)
        {
        }

        protected override AddVilleUseCaseResponseDTO TreatRequestDTO(IPortsUnitOfWork portsUnitOfWork, AddVilleUseCaseRequestDTO requestDTO)
        {
            Ville ville = portsDTOsMapper.Map<AddVilleUseCaseRequestDTO, Ville>(requestDTO);

            portsUnitOfWork.VilleRepository.Add(ville);
            portsUnitOfWork.Commit();

            AddVilleUseCaseResponseDTO retour = portsDTOsMapper.Map<Ville, AddVilleUseCaseResponseDTO>(ville);
            return retour;
        }
    }

}
