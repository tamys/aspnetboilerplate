using System;
using System.Linq;
using Abp.Dependency;
using IObjectMapper = Abp.ObjectMapping.IObjectMapper;

namespace Abp.Mapperly;

public class MapperlyObjectMapper : IObjectMapper
{
    private readonly IIocManager _iocManager;

    public MapperlyObjectMapper(IIocManager iocManager)
    {
        _iocManager = iocManager;
    }

    public TDestination Map<TDestination>(object source)
    {
        if (source == null)
        {
            return default;
        }

        var sourceType = source.GetType();
        var destinationType = typeof(TDestination);

        var mappers = _iocManager.ResolveAll<IMapperlyMapper>();
        try
        {
            foreach (var mapper in mappers)
            {
                if (mapper.CanMap(sourceType, destinationType))
                {
                    return mapper.Map<TDestination>(source);
                }
            }
        }
        finally
        {
            foreach (var mapper in mappers)
            {
                _iocManager.Release(mapper);
            }
        }

        throw new AbpException(
            $"No Mapperly mapper found to map from {sourceType.FullName} to {destinationType.FullName}. " +
            "Ensure you have registered an IMapperlyMapper implementation that handles this mapping.");
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        if (source == null)
        {
            return default;
        }

        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        var mappers = _iocManager.ResolveAll<IMapperlyMapper>();
        try
        {
            foreach (var mapper in mappers)
            {
                if (mapper.CanMap(sourceType, destinationType))
                {
                    return mapper.Map<TSource, TDestination>(source, destination);
                }
            }
        }
        finally
        {
            foreach (var mapper in mappers)
            {
                _iocManager.Release(mapper);
            }
        }

        throw new AbpException(
            $"No Mapperly mapper found to map from {sourceType.FullName} to {destinationType.FullName}. " +
            "Ensure you have registered an IMapperlyMapper implementation that handles this mapping.");
    }

    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var destinationType = typeof(TDestination);
        var sourceType = source.ElementType;

        var mappers = _iocManager.ResolveAll<IMapperlyMapper>();
        try
        {
            foreach (var mapper in mappers)
            {
                if (mapper.CanMap(sourceType, destinationType))
                {
                    return mapper.ProjectTo<TDestination>(source);
                }
            }
        }
        finally
        {
            foreach (var mapper in mappers)
            {
                _iocManager.Release(mapper);
            }
        }

        throw new AbpException(
            $"No Mapperly mapper found to project from {sourceType.FullName} to {destinationType.FullName}. " +
            "Ensure you have registered an IMapperlyMapper implementation that handles this projection.");
    }
}
