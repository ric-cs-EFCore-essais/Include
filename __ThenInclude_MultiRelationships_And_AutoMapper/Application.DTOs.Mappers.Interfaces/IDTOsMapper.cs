using System.Collections.Generic;


namespace Application.DTOs.Mappers.Interfaces
{
    public interface IDTOsMapper
    {
        TDestination Map<TSource, TDestination>(TSource source) where TDestination : new();

        IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IEnumerable<TSource> source) where TDestination : new();
    }
}
