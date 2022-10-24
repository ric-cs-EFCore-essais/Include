using AutoMapper;

namespace Infra.Mappers.DTOs.Ports.AutoMapper
{
    public class PortsAutoMapperConfiguration
    {
        public MapperConfiguration GetInstance()
        {
            MapperConfiguration retour = new MapperConfiguration(
                (IMapperConfigurationExpression config) => {

                    config.AddProfile<PortsDTOsAutoMapperProfile>();
                }
            );

            return retour;
        }

    }
}
