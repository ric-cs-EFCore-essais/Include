using System.Linq;

using AutoMapper;

using Application.DTOs.Mappers.Interfaces.Ports;


namespace Infra.Mappers.DTOs.Ports
{
    public class PortsDTOsMapper : IPortsDTOsMapper
    {
        private readonly IMapper autoMapper;

        public PortsDTOsMapper(IMapper autoMapper)
        {
            this.autoMapper = autoMapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return autoMapper.Map<TDestination>(source);
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return autoMapper.ProjectTo<TDestination>(source);
        }
    }

}
