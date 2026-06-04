using System;
using System.Linq;

namespace Abp.Mapperly;

/// <summary>
/// Interface for Mapperly-based mapper classes.
/// Implement this interface in your partial mapper classes to integrate with the ABP object mapping system.
/// </summary>
public interface IMapperlyMapper
{
    /// <summary>
    /// Determines whether this mapper can map between the specified types.
    /// </summary>
    bool CanMap(Type sourceType, Type destinationType);

    /// <summary>
    /// Maps the source object to a new instance of the destination type.
    /// </summary>
    TDestination Map<TDestination>(object source);

    /// <summary>
    /// Maps the source object to the existing destination object.
    /// </summary>
    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

    /// <summary>
    /// Projects the input queryable to the destination type.
    /// </summary>
    IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);
}
