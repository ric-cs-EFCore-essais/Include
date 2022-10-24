using AutoMapper;

namespace Infra.Mappers.DTOs
{
    public class AutoMapperFactory
    {
        private readonly MapperConfiguration autoMapperConfig;

        public AutoMapperFactory(MapperConfiguration autoMapperConfig)
        {
            this.autoMapperConfig = autoMapperConfig;
        }

        IMapper GetInstance()
        {
            IMapper retour = autoMapperConfig.CreateMapper();
            return retour;
        }
    }
}
