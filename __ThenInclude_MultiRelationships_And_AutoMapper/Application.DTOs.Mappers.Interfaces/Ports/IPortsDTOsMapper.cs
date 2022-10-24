using System.Linq;

namespace Application.DTOs.Mappers.Interfaces.Ports
{
    public interface IPortsDTOsMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);

        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);
    }
}
