using AutoMapper;

using Domain.Entities.Ports;
using Application.DTOs.Ports.GetPort;

namespace Infra.Mappers.DTOs.Ports.AutoMapper
{
    public class PortsDTOsAutoMapperProfile : Profile
    {
        public PortsDTOsAutoMapperProfile()
        {
            this._createBindings();
        }

        private void _createBindings()
        {
            CreateMap<Port, GetPortMinimalDataUseCaseResponseDTO>()
                .ForMember(dto => dto.NomVille, opt => opt.MapFrom(port => port.Ville.Nom))
                .ForMember(dto => dto.NombreBateaux, opt => opt.MapFrom(port => port.Bateaux.Count));
        }

    }

}
