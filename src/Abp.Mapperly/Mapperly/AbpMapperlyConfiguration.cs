using System;
using System.Collections.Generic;

namespace Abp.Mapperly;

public class AbpMapperlyConfiguration : IAbpMapperlyConfiguration
{
    public List<Action<MapperlyConfigurationContext>> Configurators { get; }

    public AbpMapperlyConfiguration()
    {
        Configurators = new List<Action<MapperlyConfigurationContext>>();
    }
}
