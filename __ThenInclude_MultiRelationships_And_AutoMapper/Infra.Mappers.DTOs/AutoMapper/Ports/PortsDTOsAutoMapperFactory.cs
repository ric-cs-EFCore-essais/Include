using AutoMapper;

using Application.DTOs.Mappers.Interfaces.Ports;

namespace Infra.Mappers.DTOs.AutoMapper.Ports
{
    public class PortsDTOsAutoMapperFactory
    {
        private readonly AutoMapperFactory autoMapperFactory;

        private IPortsDTOsMapper portsDTOsMapper;

        public PortsDTOsAutoMapperFactory()
        {
            autoMapperFactory = new AutoMapperFactory(new PortsDTOsAutoMapperConfiguration());
        }

        public IPortsDTOsMapper GetSingleton()
        {
            var retour = portsDTOsMapper ?? (portsDTOsMapper = CreatePortsDTOsMapper());
            return retour;
        }

        private IPortsDTOsMapper CreatePortsDTOsMapper()
        {
            var retour = new PortsDTOsAutoMapper(GetAutoMapper());
            return retour;
        }

        private IMapper GetAutoMapper()
        {
            return autoMapperFactory.GetInstance();
        }
    }
}
