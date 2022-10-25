using AutoMapper;

using Application.DTOs.Mappers.Interfaces.Ports;


namespace Infra.Mappers.DTOs.AutoMapper.Ports
{
    internal class PortsDTOsAutoMapper : DTOsAutoMapper, IPortsDTOsMapper
    {
        public PortsDTOsAutoMapper(IMapper autoMapper) : base(autoMapper)
        {

        }
    }

}
