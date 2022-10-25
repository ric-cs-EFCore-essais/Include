using AutoMapper;

namespace Infra.Mappers.DTOs.AutoMapper
{
    public class AutoMapperFactory
    {
        private readonly MapperConfiguration autoMapperConfig;

        public AutoMapperFactory(MapperConfiguration autoMapperConfig)
        {
            this.autoMapperConfig = autoMapperConfig;
        }

        public IMapper GetInstance()
        {
            IMapper retour = autoMapperConfig.CreateMapper();
            return retour;
        }
    }
}
