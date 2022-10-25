using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Application.DTOs.Mappers.Interfaces;


namespace Infra.Mappers.DTOs.AutoMapper
{
    public class DTOsAutoMapper : IDTOsMapper
    {
        private readonly IMapper autoMapper;

        public DTOsAutoMapper(IMapper autoMapper)
        {
            this.autoMapper = autoMapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
            where TDestination : new()
        {
            return autoMapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IEnumerable<TSource> source)
            where TDestination : new()
        {
            return autoMapper.ProjectTo<TDestination>(source.AsQueryable<TSource>()).AsEnumerable<TDestination>();
        }
    }

}
