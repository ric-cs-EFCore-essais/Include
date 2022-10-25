using AutoMapper;

namespace Infra.Mappers.DTOs.AutoMapper.Ports
{
    internal class PortsDTOsAutoMapperConfiguration : MapperConfiguration
    {
        public PortsDTOsAutoMapperConfiguration() : 
            base(
                (IMapperConfigurationExpression autoMapperConfigExpression) => {

                    autoMapperConfigExpression.AddProfile<PortsDTOsAutoMapperProfile>();
                }
            )
        {
        }
    }
}
